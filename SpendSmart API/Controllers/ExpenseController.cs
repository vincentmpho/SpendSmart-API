using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendSmart_API.Data;
using SpendSmart_API.Models;

namespace SpendSmart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet("{month}")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpensesByMonth(string month)
        {
            var expenses = await _context.Expenses
                .Where(e => e.Month == month)
                .ToListAsync();

            return Ok(expenses);
        }

        
        [HttpPost]
        public async Task<ActionResult<Expense>> AddExpense([FromBody] Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExpensesByMonth), new { month = expense.Month }, expense);
        }


    }
}
