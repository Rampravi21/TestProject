using ManageInvoiceService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ManageInvoiceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {

        private readonly VirtuagymFinancialTestContext _context;

        public CheckInController(VirtuagymFinancialTestContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Memberships>> UserCheckIn(int id)
        {
            var users = await _context.Users.FindAsync(id);
            var membershipUsers = await _context.Memberships.ToListAsync();

            if (users == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
