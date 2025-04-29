using ComputergyAPI.DTOs.Payment;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _paymentService;

        public PaymentController(IPayment paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-update")]
        public async Task<IActionResult> CreateUpdatePaymentCard([FromBody] CreateUpdatePaymentCardDTO input)
        {
            try
            {
                var result = await _paymentService.CreateUpdatePaymentCard(input);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);


            }
            
        }

        [HttpGet("GetAllPaymentCards")]
        public async Task<IActionResult> GetAllPaymentCards(int userId)
        {
            try
            {
                var result = await _paymentService.GetAll(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }

        [HttpGet("{cardId}")]
        public async Task<IActionResult> GetPaymentCard(int cardId)
        {
            try
            {
                var result = await _paymentService.GetPaymentCard(cardId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            


        }

        [HttpDelete("{cardId}")]
        public async Task<IActionResult> RemovePaymentCard(int cardId)
        {
            try
            {
                var result = await _paymentService.RemovePaymentCard(cardId);
                if (result)
                    return Ok("Payment card removed successfully.");
                else
                    return BadRequest("Failed to remove payment card.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
    }
}
