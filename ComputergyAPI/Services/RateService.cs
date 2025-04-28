using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Rating.Request;
using ComputergyAPI.DTOs.Rating.Response;
using ComputergyAPI.Entites;
using ComputergyAPI.Helpers.RateValidation;
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

        public async Task<string> CreateRate(CreateRateDTO input)
        {
            
            Rate rate = new Rate(); 
            if (RateAmountValidation.CheckRateAmount(input.RateAmount))
            {
                rate.RateAmount = input.RateAmount;
            }
            
            rate.Message = input.Massege;
            rate.PersonId = input.PersonId;
            rate.OrderId = input.OrderId;
            rate.UpdatedBy = "System";
            rate.CreatedBy = "System";

            _computergyDbContext.Add(rate);
            _computergyDbContext.SaveChanges();
            return "created Successfully";
        }

        public async Task<List<GetRateDTO>> GetRateByOrderID(int id)
        {
            var rates = _computergyDbContext.Rate.Where(x => x.OrderId == id).SingleOrDefault();
            if (rates == null)
            {
                throw new Exception("Wrong ID");
            }
            var getRate = (from rate in _computergyDbContext.Rate
                           join order in _computergyDbContext.Order
                           on rate.OrderId equals order.Id
                           select new GetRateDTO
                           {
                               Message = rate.Message,
                               PersonId = rate.PersonId,
                               OrderId = rate.OrderId,
                               RateAmount = rate.RateAmount,
                               OrderDate = order.OrderDate   
                           }).ToList();
            return getRate;
        }
    }
}
