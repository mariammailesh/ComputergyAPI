using ComputergyAPI.DTOs.Order;
using ComputergyAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _service;

        public OrderController(IOrder service)
        {
            _service = service;
        }
        public async Task<IActionResult> CreateUpdateOrder(CreateUpdateOrderInputDTO input)
        {
            try
            {
                var response = await _service.CreateUpdateOrder(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var response = await _service.DeleteOrder(id);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        public async Task<IActionResult> GetAllOrder()
        {
            try
            {
                var response = await _service.GetAllOrder();
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        public async Task<IActionResult?> GetOneOrder(int id)
        {
            try
            {
                var response = await _service.GetOneOrder(id);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
        public async Task<IActionResult> SearchOrder(SearchOrderInputDTO input)
        {
            try
            {
                var response = await _service.SearchOrder(input);
                return Ok($"{response}");
            }
            catch (Exception ex)
            {
                Log.Error($"An Error Has been Ocuured {ex.Message}");
                Log.Error(ex.StackTrace);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
