using ComputergyAPI.Contexts;
using ComputergyAPI.Interfaces;
using ComputergyAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputergyAPI.DTOs.Carts;

namespace ComputergyAPI.Controllers.AuthenticationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _CartServices;

        public CartController(ICart CartServices)
        {
            _CartServices = CartServices;
        }

        [HttpPost("Create-Cart/{personId}")]
        public async Task<IActionResult> CreateCart([FromRoute] int personId)
        {
            try
            {
                if (CartitemValidationHelper.IsValidId(personId))
                {
                    return Ok(await _CartServices.CreateCart(personId));
                }
                else
                {
                    throw new Exception("Pesron Id Must Be Greater Than Zero!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);  
            }
        }
        [HttpPost("Add-Update-Cart{item}")]
        public async Task<IActionResult> AddUpdateCart([FromBody] CartItemDTO itemDTO)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(itemDTO.CartId) && CartitemValidationHelper.IsValidId(itemDTO.ItemId) 
                    && CartitemValidationHelper.IsValidQuentity(itemDTO.Quantity) 
                    && CartitemValidationHelper.IsValidTotalPrice(itemDTO.TotalPrice))
                {
                    return Ok(_CartServices.AddUpdateCart(itemDTO));
                }

                throw new Exception("CartId, ItemID, Quantity and TotalPrice Must Be Greater Than Zero!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Remove-Item{itemId}")]
        public async Task<IActionResult> RemoveFromCart([FromRoute] int id)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(id))
                    return Ok(_CartServices.RemoveFromCart(id));

                throw new Exception("ItemID Must Be Greater Than Zero!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("Clear-Cart{cartId}")]
        public async Task<IActionResult> ClearCart([FromRoute] int id)
        {
            try
            {
                if(CartitemValidationHelper.IsValidId(id))
                    return Ok(_CartServices.ClearCart(id));

                throw new Exception("CartID Must Be Greater Than Zero!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
