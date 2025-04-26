using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Products;
using ComputergyAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductController(ProductsService _productsService)
        {
            this._productsService = _productsService;
        }


        [HttpPost]
        [Route("Create new Product")]
        public async Task<IActionResult> CreateNewProduct(ProductCreateDTO dto)
        {
            try
            {
                return Ok( _productsService.CreateProduct(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost]
        [Route("Update Product")]

        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO dto)
        {
            try
            {
                return Ok(_productsService.UpdateProduct(dto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete Product")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(_productsService.RemoveProduct(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}