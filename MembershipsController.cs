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
    public class MembershipsController : ControllerBase
    {
        private readonly VirtuagymFinancialTestContext _context;

        public MembershipsController(VirtuagymFinancialTestContext context)
        {
            _context = context;
        }

        // GET: api/Memberships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Memberships>>> GetMemberships()
        {
            return await _context.Memberships.ToListAsync();
        }

        // GET: api/Memberships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Memberships>> GetMemberships(int id)
        {
            var memberships = await _context.Memberships.FindAsync(id);

            if (memberships == null)
            {
                return NotFound();
            }

            return memberships;
        }

        // PUT: api/Memberships/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemberships(int id, Memberships memberships)
        {
            if (id != memberships.MembershipId)
            {
                return BadRequest();
            }

            _context.Entry(memberships).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Memberships
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Memberships>> PostMemberships(Memberships memberships)
        {
            _context.Memberships.Add(memberships);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMemberships", new { id = memberships.MembershipId }, memberships);
        }

        // DELETE: api/Memberships/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Memberships>> DeleteMemberships(int id)
        {
            var memberships = await _context.Memberships.FindAsync(id);
            if (memberships == null)
            {
                return NotFound();
            }

            _context.Memberships.Remove(memberships);
            await _context.SaveChangesAsync();

            return memberships;
        }

        private bool MembershipsExists(int id)
        {
            return _context.Memberships.Any(e => e.MembershipId == id);
        }
    }
}
