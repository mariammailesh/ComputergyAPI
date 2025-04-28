using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscount _discountService;

        public DiscountsController(IDiscount discountService)
        {
            _discountService = discountService;
        }

        [HttpPost("Create-Discount")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDTO input)
        {
            try
            {
                var result = await _discountService.CreateAsync(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-allDiscounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            try
            {
                var discounts = await _discountService.GetAllAsync();
                return Ok(discounts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var existing = await _discountService.GetByIdAsync(id);
                return existing is null ? NotFound() : Ok(existing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update Discount/{id}")]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] UpdateDiscountDTO input)
        {
            try
            {
                var result = await _discountService.UpdateAsync(id, input);
                if (result is null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-Discount/{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            try
            {
                var result = await _discountService.DeleteAsync(id);
                if (!result)
                    return NotFound("Discount not found");

                return Ok("Discount deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
