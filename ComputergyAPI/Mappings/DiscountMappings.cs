using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputergyAPI.DTOs.Discount;
using ComputergyAPI.Entites;

namespace ComputergyAPI.Mappings
{
    public static class DiscountMappings
    {
        public static DiscountDTO ToDiscountDTO(this Discount entity)
        {
            return new DiscountDTO()
            {
                Title = entity.Title,
                Percentage = entity.Percentage,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Code = entity.Code
            };
        }
    }
}