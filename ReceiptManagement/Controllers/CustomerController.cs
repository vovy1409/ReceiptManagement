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
    public class CustomerController : ControllerBase
    {
        private readonly DB _context;
        public CustomerController(DB context) {
            _context = context;
        }
        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST api/Customer
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {

            var check = await _context.Customers.Where(x => x.CustomerID == customer.CustomerID).FirstOrDefaultAsync();
            if (check != null )
            {
                return BadRequest();
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", new { id = customer.Id }, customer);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(long id, Customer customer)
        {
            var cus = await _context.Customers.FindAsync(id);
            if (cus == null)
            {
                return NotFound();
            }
            cus.CustomerID = customer.CustomerID;
            cus.Name = customer.Name;
            cus.Address = customer.Address;
            _context.Customers.Update(cus);
            await _context.SaveChangesAsync();
            return Ok(cus);
        }

        // DELETE api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(long id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
