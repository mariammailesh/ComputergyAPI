using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class AuthanicationService : IAuthanication
    {
        private readonly ComputergyDbContext _computergyDbContext;
        private readonly ITokenProvider _tokenProvider;
        public AuthanicationService(ComputergyDbContext computergyDbContext, ITokenProvider tokenProvider)
        {
            _computergyDbContext = computergyDbContext;
            _tokenProvider = tokenProvider;

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
            var user = _computergyDbContext.Persons.Where(u => u.Email == email && u.IsLogedIn == false).SingleOrDefault();
            if (user == null)
            {
                return false;
            }
            Random otp = new Random();
            user.OTP = otp.Next(11111, 99999).ToString();
            user.ExpireOTP = DateTime.Now.AddMinutes(3);
            //send otp via email

            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges();

            return true;
        }

        public async Task<string> SignIn(SignInInputDTO input)
        {
            var user = _computergyDbContext.Persons.Where(u=>u.Email == input.Email && u.Password == input.Password && u.IsLogedIn == false).SingleOrDefault();
            if (user == null) {
                return "User not found";
            }

            Random random = new Random();
            var otp = random.Next(11111,99999);
            user.OTP = otp.ToString();

            user.ExpireOTP = DateTime.Now.AddMinutes(5);
            //Send code via email
            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges(); 

            return "Check your email OTP has been sent!";
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
            }
            else
            {
                user.LastLoginTime = DateTime.Now;
                user.IsLogedIn = true;
            }
            
            user.ExpireOTP = null;
            user.OTP = null;

            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges();
            string jwtToken = _tokenProvider.CreateToken(user);

            return jwtToken;
        }
    }
}
