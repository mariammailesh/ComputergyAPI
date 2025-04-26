using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Interfaces;
using System;

namespace ComputergyAPI.Services
{
    public class ProductsService : IProducts
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public ProductsService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }
        public async Task<ProductDTO> CreateProduct(ProductCreateDTO dto)
        {
            throw new Exception("Product not found.");
        }
        public async Task<bool> RemoveProduct(int id)
        {
            throw new Exception("Product not found.");
        }
        public async Task<ProductDTO> UpdateProduct(ProductUpdateDTO dto)
        {
            throw new Exception("Product not found.");
        }
        public async Task<ProductDTO> GetAllProducts()
        {
            throw new Exception("Product not found.");
        }
        public async Task<ProductDTO?> GetOneProduct(int id)
        {
            var existing = await _computergyDbContext.Products.FindAsync(id);
            if (existing is null)
                return null;
            return new ProductDTO()
            {
                Id = existing.Id,
                ProductName = existing.ProductName,
                Price = existing.Price,
                ImageUrl = existing.ImageUrl,
                Category = existing.Category,
                Brand = existing.Brand
            };
        }
        public async Task<ProductDTO> SearchProduct(SearchInputProductsDTO input)
        {
            throw new Exception("Product not found.");
        }
    }
}
