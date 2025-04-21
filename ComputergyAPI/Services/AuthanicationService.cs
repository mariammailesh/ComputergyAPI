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
        public Task<bool> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendOTP(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignIn(SignInInputDTO input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignOut(int userId)
        {
            throw new NotImplementedException();
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
