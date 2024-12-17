using SpendSmart_API.Models.DTOs;
using SpendSmart_API.Models;
using SpendSmart_API.Repositories.Interface;

namespace SpendSmart_API.Service
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;

        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task AddIncomeAsync(IncomeDto incomeDto)
        {
            var income = new Income
            {
                Month = incomeDto.Month,
                Source = incomeDto.Source,
                Amount = incomeDto.Amount,
                Investments = incomeDto.Investments,
                CreatedAt = DateTime.UtcNow
            };

            await _incomeRepository.AddAsync(income);
        }

        public async Task<List<IncomeDto>> GetIncomesByMonthAsync(string month)
        {
            var incomes = await _incomeRepository.GetByMonthAsync(month);
            return incomes.Select(i => new IncomeDto
            {
                Month = i.Month,
                Source = i.Source,
                Amount = i.Amount,
                Investments = i.Investments
            }).ToList();
        }

        public async Task SaveAllIncomesAsync(List<IncomeDto> incomeDtos)
        {
            var incomes = incomeDtos.Select(i => new Income
            {
                Month = i.Month,
                Source = i.Source,
                Amount = i.Amount,
                Investments = i.Investments,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            await _incomeRepository.AddBulkAsync(incomes);
        }
    }
}
