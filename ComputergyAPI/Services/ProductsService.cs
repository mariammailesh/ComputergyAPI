using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace ComputergyAPI.Services
{
    public class ProductsService: IProducts
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
        public async Task<List<ProductDTO>> GetAllProducts()
        { 
          return _computergyDbContext.Products.Select(x=> new ProductDTO()
          {
              Id = x.Id,
          }
          ).ToList();

         
        }
        public async Task<ProductDTO> GetOneProduct(int id)
        { 
            throw new Exception("Product not found."); 
        }
        public async Task<ProductDTO> SearchProduct(SearchInputProductsDTO input)
        {
            throw new Exception("Product not found.");
        }
    }
}
