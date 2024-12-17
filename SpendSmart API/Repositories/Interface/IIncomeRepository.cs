using SpendSmart_API.Models;

namespace SpendSmart_API.Repositories.Interface
{
    public interface IIncomeRepository
    {
        Task AddAsync(Income income);
        Task<List<Income>> GetByMonthAsync(string month);
        Task AddBulkAsync(List<Income> incomes);
    }
}
