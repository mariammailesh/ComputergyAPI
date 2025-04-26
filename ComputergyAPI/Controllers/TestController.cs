using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController
    {

        [HttpGet("error")]
        public IActionResult GenerateError()
        {
            throw new Exception("Test exception for logging!");
        }

    }

}
