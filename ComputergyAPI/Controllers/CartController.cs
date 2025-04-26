using ComputergyAPI.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public CartController(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }

        
    }
}
