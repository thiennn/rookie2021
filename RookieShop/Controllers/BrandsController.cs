using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RookieShop.Data;
using RookieShop.Models;
using SharedVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;


        public BrandsController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<ProductVm>> Get()
        {
            var brands = await _myDbContext.Brands.Select(x => new BrandVm {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();

            return Ok(brands);
        }
    }
}
