namespace ComputergyAPI.DTOs.Products
{
    public class SearchInputProductsDTO
    {
        public string Name { get; set; }
        public bool IsHasDiscount { get; set; }
        public string Brand { get; set; }
        public float ProductPrice { get; set; }
        public string Category { get; set; }

    }
}
