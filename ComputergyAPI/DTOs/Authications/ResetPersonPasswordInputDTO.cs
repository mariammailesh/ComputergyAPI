namespace ComputergyAPI.DTOs.Authications
{
    public class ResetPersonPasswordInputDTO
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OTP  { get; set; }
    }
}
