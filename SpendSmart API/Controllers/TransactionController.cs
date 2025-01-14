using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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



        [HttpGet("{month}")]
        public async Task<IActionResult> GetTransactionsByMonth(string month)
        {
            if (string.IsNullOrEmpty(month))
            {
                return BadRequest("Month is required");
            }





            try
            {
                var transactions = await _context.Transactions
                .Where(t => t.Month == month)
                .ToListAsync();





                if (transactions == null || !transactions.Any())
                {
                    return NotFound($"No transactions found for the month: {month}");
                }





                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
