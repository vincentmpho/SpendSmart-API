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
            try
            {
                var expenses = await _context.Expenses
                    .Where(e => e.Month == month)
                    .ToListAsync();

                return Ok(expenses);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error retrieving expenses for month {month}: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> AddExpense([FromBody] Expense expense)
        {
            try
            {
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetExpensesByMonth), new { month = expense.Month }, expense);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error adding expense: {ex.Message}");
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> SaveAllExpenses([FromBody] List<Expense> expenses)
        {
            if (expenses == null || !expenses.Any())
            {
                return BadRequest("Expenses cannot be null or empty.");
            }

            try
            {
                foreach (var expense in expenses)
                {
                    // Reset Id to let the database handle it
                    expense.Id = 0;
                }

                _context.Expenses.AddRange(expenses);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Expenses saved successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error saving bulk expenses: {ex.Message}");
            }
        }
    }
}
