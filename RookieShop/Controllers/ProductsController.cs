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
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;


        public ProductsController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<ProductVm>> Get()
        {
            var products = await _myDbContext.Products.Select(x => new ProductVm {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductFormVm model)
        {
            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                BrandId = model.BrandId
            };

            _myDbContext.Products.Add(product);
            await _myDbContext.SaveChangesAsync();

            return Accepted();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductFormVm model)
        {
            var product = await _myDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;

            await _myDbContext.SaveChangesAsync();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _myDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _myDbContext.Products.Remove(product);

            await _myDbContext.SaveChangesAsync();
            return Accepted();
        }
    }
}
