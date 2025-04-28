namespace ComputergyAPI.DTOs.Order
{
    public class SearchOrderInputDTO
    {
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string Address { get; set; }
        public string PaymentType { get; set; }
    }
}
