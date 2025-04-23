namespace ComputergyAPI.DTOs.Rating
{
    public class CreateRateDTO
    {
        public int PersonId { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }
        public int RateAmount { get; set; }
    }
}
