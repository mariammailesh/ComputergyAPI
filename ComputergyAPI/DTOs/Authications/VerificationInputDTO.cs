namespace ComputergyAPI.DTOs.Authications
{
    public class VerificationInputDTO
    {
        public string Email {  get; set; }

        public string OTPCode { get; set; }

        public bool IsSignup { get; set; }
    }
}
