using ComputergyAPI.DTOs.Authications;

namespace ComputergyAPI.Interfaces
{
    public interface IAuthanication
    {
        //define sigature for the targeted method 
        Task<string> SignUp(SignUpInputDTO input);
        Task<string> SignIn(SignInInputDTO input);
        Task<bool> SendOTP(string email);
        Task<bool> ResetPersonPassword(ResetPersonPasswordInputDTO input);
        Task<bool> SignOut(int userId);
    }
}
