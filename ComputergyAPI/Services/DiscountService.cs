using ComputergyAPI.Contexts;
using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Entites;
using ComputergyAPI.Interfaces;
using ComputergyAPI.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ComputergyAPI.Services
{
    public class DiscountService : IDiscount
    {
        private readonly ComputergyDbContext _context;
        public DiscountService(ComputergyDbContext computergyDbContext)
        {
            _context = computergyDbContext;
        }

        public async Task<List<DiscountDTO>> GetAllAsync()
        {
            return await _context.Discounts.Select(d =>
                new DiscountDTO()
                {
                    Title = d.Title,
                    Percentage = d.Percentage,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    Code = d.Code
                }
            ).ToListAsync();
        }
        public async Task<DiscountDTO?> GetByIdAsync(int id)
        {
            return (await _context.Discounts.FindAsync(id))?.ToDiscountDTO();
        }
        public async Task<DiscountDTO> CreateAsync(CreateDiscountDTO input)
        {
            var added = new Discount()
            {
                Code = input.Code,
                Title = input.Title,
                Percentage = input.Percentage,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                ImageUrl = input.ImageUrl,
                LimitUser = input.LimitUser,
                Description = input.Description,
                LimitAmount = input.LimitAmount
            };
            await _context.AddAsync(added);
            await _context.SaveChangesAsync();

            return added.ToDiscountDTO();
        }
        public async Task<DiscountDTO?> UpdateAsync(int discountId, UpdateDiscountDTO input)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount == null)
                return null;

            discount.Title = input.Title ?? discount.Title;
            discount.Percentage = input.Percentage ?? discount.Percentage;
            discount.StartDate = input.StartDate ?? discount.StartDate;
            discount.EndDate = input.EndDate ?? discount.EndDate;
            discount.Code = input.Code ?? discount.Code;

            discount.ImageUrl = input.ImageUrl ?? discount.ImageUrl;
            discount.Description = input.Description ?? discount.Description;
            discount.LimitUser = input.LimitUser ?? discount.LimitUser;
            discount.LimitAmount = input.LimitAmount ?? discount.LimitAmount;


            await _context.SaveChangesAsync();
            return discount.ToDiscountDTO();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null)
                return false;

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}