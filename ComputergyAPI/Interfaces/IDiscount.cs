using ComputergyAPI.DTOs.Discount;

namespace ComputergyAPI.Interfaces
{

    public interface IDiscount
    {
        public Task<List<DiscountDTO>> GetAllAsync();
        public Task<DiscountDTO?> GetByIdAsync(int id);
        public Task<DiscountDTO> CreateAsync(CreateDiscountDTO input);
        public Task<DiscountDTO?> UpdateAsync(int id, UpdateDiscountDTO input);
        public Task<bool> DeleteAsync(int id);

    }
}