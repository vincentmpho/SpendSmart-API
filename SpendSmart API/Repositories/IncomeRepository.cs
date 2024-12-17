using Microsoft.EntityFrameworkCore;
using SpendSmart_API.Data;
using SpendSmart_API.Models;
using SpendSmart_API.Repositories.Interface;

namespace SpendSmart_API.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ApplicationDbContext _context;

        public IncomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Income income)
        {
            await _context.Incomes.AddAsync(income);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Income>> GetByMonthAsync(string month)
        {
            return await _context.Incomes.Where(i => i.Month == month).ToListAsync();
        }

        public async Task AddBulkAsync(List<Income> incomes)
        {
            await _context.Incomes.AddRangeAsync(incomes);
            await _context.SaveChangesAsync();
        }
    }
}
