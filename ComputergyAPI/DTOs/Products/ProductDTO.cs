namespace ComputergyAPI.DTOs.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public string? ImageUrl { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}
