using Microsoft.EntityFrameworkCore;
using SpendSmart_API.Models;

namespace SpendSmart_API.Data
{
    public class ApplicationDbContext : DbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; } 
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<TodoTransaction> TodoTransactions { get; set; }
    }
}
