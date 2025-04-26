using ComputergyAPI.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace ComputergyAPI.Services
{
    public class Discount
    {
        private readonly ComputergyDbContext _computergyDbContext;
        public Discount(ComputergyDbContext computergyDbContext)
        {
            _computergyDbContext = computergyDbContext;
        }
        //public async Task<IActionResult> Discount(Discount input)
        //{

        //    throw new NotImplementedException();
        //}

    }
}
