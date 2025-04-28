namespace ComputergyAPI.DTOs.Order
{
    public class OrderDTO
    {
        public int ID { get; set; } 
        public int PersonID { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public int? PaymentMethodID { get; set; }

    }
}
