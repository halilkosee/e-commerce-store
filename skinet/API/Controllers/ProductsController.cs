
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await  _context.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<Product>> GetPoduct(int id)
        {
            var products = await  _context.Products.ToListAsync();
            return  await _context.Products.FindAsync(id);
        }
    }
}