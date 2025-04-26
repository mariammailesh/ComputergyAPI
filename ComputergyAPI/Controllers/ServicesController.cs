using ComputergyAPI.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public ServicesController(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }

        [Htt]
    }
}
