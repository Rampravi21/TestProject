
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageInvoiceService.Models;

namespace ManageInvoiceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly VirtuagymFinancialTestContext _context;

        public InvoicesController(VirtuagymFinancialTestContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoices>>> GetInvoices()
        {
            return await _context.Invoices.ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoices>> GetInvoices(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);

            if (invoices == null)
            {
                return NotFound();
            }

            return invoices;
        }

        // PUT: api/Invoices/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoices(int id, Invoices invoices)
        {
            if (id != invoices.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoices).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return CreatedAtAction("GetInvoices", new { id = invoices.InvoiceId }, invoices);
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<Invoices>> PostInvoices(Invoices invoices)
        {
            _context.Invoices.Add(invoices);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoices", new { id = invoices.InvoiceId }, invoices);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Invoices>> DeleteInvoices(int id)
        {
            var invoices = await _context.Invoices.FindAsync(id);
            if (invoices == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoices);
            await _context.SaveChangesAsync();

            return invoices;
        }

        private bool InvoicesExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
