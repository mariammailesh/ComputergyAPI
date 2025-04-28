namespace ComputergyAPI.DTOs.Payment
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; } = "Ok";
        public string? Notes { get; set; }
        public bool IsCompleated { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
    }
}
