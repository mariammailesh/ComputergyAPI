namespace ComputergyAPI.Entites
{
    public class Discount : MainEntity


    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int? ProductId { get; set; }
        

    }
}
