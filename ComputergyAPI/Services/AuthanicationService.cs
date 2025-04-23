using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class AuthanicationService : IAuthanication
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public AuthanicationService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
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

            user.LastLoginTime = DateTime.Now;   
            user.IsLogedIn = true;

            _computergyDbContext.Update(user);
            _computergyDbContext.SaveChanges(); 

            return "Token!";
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
            _computergyDbContext.Persons.Add(person);
            _computergyDbContext.SaveChanges();
            return "Account Created Successfully";
        }
    }
}
