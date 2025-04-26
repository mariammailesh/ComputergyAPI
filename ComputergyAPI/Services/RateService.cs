using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Rating;
using ComputergyAPI.Interfaces;

namespace ComputergyAPI.Services
{
    public class RateService : IRate
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public RateService(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }

        public Task<string> CreateRate(CreateRateDTO input)
        {
            throw new NotImplementedException();
        }
    }
}
