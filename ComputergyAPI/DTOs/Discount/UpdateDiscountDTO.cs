using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputergyAPI.DTOs.Discount
{
    public class UpdateDiscountDTO
    {
        public string? Code { get; set; }
        public string? Title { get; set; }
        public double? Percentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ImageUrl { get; set; }
        public int? LimitUser { get; set; }
        public string? Description { get; set; }
        public float? LimitAmount { get; set; }
    }
}