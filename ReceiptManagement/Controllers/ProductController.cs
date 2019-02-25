using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceiptManagement.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReceiptManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DB _context;
        public ProductController(DB context)
        {
            _context = context;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            var check = await _context.Products.Where(x => x.ProductID == product.ProductID).FirstOrDefaultAsync();
            if (check != null)
            {
                return BadRequest();
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = product.Id }, product);
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(long id, Product product)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }
            prod.ProductID = product.ProductID;
            prod.Name = prod.Name;
            _context.Products.Update(prod);
            await _context.SaveChangesAsync();
            return Ok(prod);
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(long id)
        {
            var prod = await _context.Products.FindAsync(id);
            if (prod == null)
            {
                return NotFound();
            }
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
            return prod;
        }
    }
}
