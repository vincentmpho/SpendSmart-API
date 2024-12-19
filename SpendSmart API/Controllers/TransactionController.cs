using Microsoft.AspNetCore.Mvc;
using SpendSmart_API.Data;
using SpendSmart_API.Models;

namespace SpendSmart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction) 
        {
            if (transaction == null)
            {
                return BadRequest("Transaction data is null");
            }

            // Add transaction to the database
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }
    }
}
