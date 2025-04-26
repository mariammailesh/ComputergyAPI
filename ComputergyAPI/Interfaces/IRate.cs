using ComputergyAPI.DTOs.Authications;
using ComputergyAPI.DTOs.Rating;

namespace ComputergyAPI.Interfaces
{
    public interface IRate
    {
        Task<string> CreateRate(CreateRateDTO input);
        
    }
}
