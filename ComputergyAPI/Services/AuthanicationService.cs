using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Entites;
using ComputergyAPI.Helpers.JWT;
using ComputergyAPI.Helpers.SendEmailWithSendGrid;
using ComputergyAPI.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
namespace ComputergyAPI.Services
{
    public class AuthanicationService : IAuthanication
    {
        private readonly ComputergyDbContext _computergyDbContext;
        private readonly ITokenProvider _tokenProvider;

        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly GenerateJwtToken _jwtTokenGenerator;
        private readonly SendEmailWithSendGrid _sendEmailService;

        public AuthanicationService(ComputergyDbContext computergyDbContext, IConfiguration configuration, SendEmailWithSendGrid sendEmailService)
        {
            _computergyDbContext = computergyDbContext;
            _jwtTokenGenerator = new GenerateJwtToken(configuration);
            _sendEmailService = sendEmailService;
        }

        public async Task<bool> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            var user = _computergyDbContext.Persons.Where(u => u.Email == input.Email && u.OTP == input.OTP
            && u.IsLogedIn == false && u.ExpireOTP>DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            if (input.Password!=input.ConfirmPassword)
            {
                return false;
            }
            user.Password= input.ConfirmPassword;
            user.OTP = null;
            user.ExpireOTP = null;
            
            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges();

            return true;
        }

        public async Task<bool> SendOTP(string email)
        {
            try
            {
                var user = _computergyDbContext.Persons.Where(u => u.Email == email && u.IsLogedIn == false).SingleOrDefault();
                if (user == null)
                {
                    return false;
                }
                Random otp = new Random();
                user.OTP = otp.Next(11111, 99999).ToString();
                user.ExpireOTP = DateTime.Now.AddMinutes(3);
                //send otp via email
                /*await _sendEmailService.SendEmailAsync(
                   toEmail: user.Email,
                   toName: $"{user.FirstName} {user.LastName}",
                   subject: "Your Verification OTP Code",
                   plainText: $"Your OTP code is {user.OTP}",
                   htmlContent: $"<strong>Your OTP code is {user.OTP}</strong>"
               );*/

                //send otp via email

                _computergyDbContext.Update(user);
                _computergyDbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public async Task<string> SignIn(SignInInputDTO input)
        {
            var user = _computergyDbContext.Persons.Where(u => u.Email == input.Email && u.Password == input.Password && u.IsLogedIn == false).SingleOrDefault();
            if (user == null)
            {
                return "User not found";
            }

            Random random = new Random();
            var otp = random.Next(11111, 99999);
            user.OTP = otp.ToString();

            user.ExpireOTP = DateTime.Now.AddMinutes(5);
            //Send code via email
            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges();

            return "Check your emnail OTP has been sent!";
        }
        public async Task<bool> SignOut(int userId)
        {
            var user = _computergyDbContext.Persons.Where(u => u.Id == userId && u.IsLogedIn == true).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            
            user.LastLoginTime = DateTime.Now;
            user.IsLogedIn = false;

            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges();

            return true;
        }

        public async Task<string> SignUp(SignUpInputDTO input)
        {
            Person person = new Person();
            person.Email = input.Email;
            person.Password = input.Password;
            person.FirstName = input.FirstName;
            person.LastName = input.LastName;
            person.CreatedBy = "System";
            person.CreationDate = DateTime.Now;

            Random random = new Random();
            var otp = random.Next(11111, 99999);
            person.OTP = otp.ToString();

            person.ExpireOTP = DateTime.Now.AddMinutes(5);
            _computergyDbContext.Persons.Add(person);
            _computergyDbContext.SaveChanges();
            // send otp code via email
            return "Verifuing Your email using otp";
        }

        public async Task<string> Verification(VerificationInputDTO input)
        {
            var user = _computergyDbContext.Persons.Where(u => u.Email == input.Email && u.OTP == input.OTPCode 
            && u.IsLogedIn == false && u.ExpireOTP > DateTime.Now).SingleOrDefault();
            if (user == null)
            {
                return "User not found";
            }

            if (input.IsSignup)
            {
                user.IsVerified = true;
                user.ExpireOTP = null;
                user.OTP = null;
                _computergyDbContext.Update(user);
                _computergyDbContext.SaveChanges();
                return "Your Account Is Verifyed";
            }
            else
            {
                user.LastLoginTime = DateTime.Now;
                user.IsLogedIn = true;
                user.ExpireOTP = null;
                user.OTP = null;

                _computergyDbContext.Update(user);
                _computergyDbContext.SaveChanges();
                string jwtToken = _tokenProvider.CreateToken(user);

                return jwtToken;
            }

        }
    }
}
