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
    public class ReceiptItemController : ControllerBase
    {
        private readonly DB _context;
        public ReceiptItemController(DB context)
        {
            _context = context;
        }
        // GET: api/ReceiptItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt_Item>>> Get()
        {
            return await _context.Receipt_Items.Include(x => x.Product).ToListAsync();
        }

        // GET api/ReceiptItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt_Item>> Get(long id)
        {
            var receiptItem = await _context.Receipt_Items.FindAsync(id);
            if (receiptItem == null)
            {
                return NotFound();
            }
            return receiptItem;
        }

        // POST api/ReceiptItem
        [HttpPost]
        public async Task<ActionResult<Receipt_Item>> Post(Receipt_Item receiptItems)
        {
            _context.Receipt_Items.Add(receiptItems);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = receiptItems.Id }, receiptItems);
        }

        // PUT api/ReceiptItem/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Receipt_Item>> Put(long id, Receipt_Item receiptItem)
        {
            var recItem = await _context.Receipt_Items.FindAsync(id);
            if (recItem == null)
            {
                return NotFound();
            }
            recItem.Product_ID = receiptItem.Product_ID;
            recItem.Quantity = receiptItem.Quantity;
            recItem.Price = receiptItem.Price;
            _context.Receipt_Items.Update(recItem);
            await _context.SaveChangesAsync();
            return Ok(recItem);
        }

        // DELETE api/ReceiptItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receipt_Item>> Delete(long id)
        {
            var recItem = await _context.Receipt_Items.FindAsync(id);
            if (recItem == null)
            {
                return NotFound();
            }
            _context.Receipt_Items.Remove(recItem);
            await _context.SaveChangesAsync();
            return recItem;
        }
    }
}
