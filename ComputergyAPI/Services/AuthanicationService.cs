using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class AuthanicationService : IAuthanication
    {
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

        public Task<string> SignUp(SignUpInputDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
