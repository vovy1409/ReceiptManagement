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
    public class ReceiptController : Controller
    {
        private readonly DB _context;
        public ReceiptController(DB context)
        {
            _context = context;
        }
        // GET: api/Receipt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> Get()
        {
            return await _context.Receipts.ToListAsync();
        }

        // GET api/Receipt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> Get(long id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }
            return receipt;
        }

        // POST api/Receipt
        [HttpPost]
        public async Task<ActionResult<Receipt>> Post(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = receipt.Id }, receipt);
        }

        // PUT api/Receipt/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Receipt>> Put(long id, Receipt receipt)
        {
            var rec = await _context.Receipts.FindAsync(id);
            if (rec == null)
            {
                return NotFound();
            }
            rec.ReceiptDate = receipt.ReceiptDate;
            rec.Customer_ID = receipt.Customer_ID;
            _context.Receipts.Update(rec);
            await _context.SaveChangesAsync();
            return Ok(rec);
        }

        // DELETE api/Receipt/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receipt>> Delete(long id)
        {
            var rec = await _context.Receipts.FindAsync(id);
            if (rec == null)
            {
                return NotFound();
            }
            _context.Receipts.Remove(rec);
            await _context.SaveChangesAsync();
            return rec;
        }
    }
}
