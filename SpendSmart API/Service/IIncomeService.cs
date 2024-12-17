using SpendSmart_API.Models.DTOs;

namespace SpendSmart_API.Service
{
    public interface IIncomeService
    {

        Task AddIncomeAsync(IncomeDto incomeDto);
        Task<List<IncomeDto>> GetIncomesByMonthAsync(string month);
        Task SaveAllIncomesAsync(List<IncomeDto> incomeDtos);
    }
}
