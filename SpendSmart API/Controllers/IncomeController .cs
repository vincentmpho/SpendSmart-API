﻿using Microsoft.AspNetCore.Mvc;
using SpendSmart_API.Models.DTOs;
using SpendSmart_API.Service;

namespace SpendSmart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] IncomeDto incomeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _incomeService.AddIncomeAsync(incomeDto);
                return Ok(new { message = "Income added successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while adding income.", error = ex.Message });
            }
        }

        [HttpGet("{month}")]
        public async Task<IActionResult> GetIncomesByMonth(string month)
        {
            try
            {
                var incomes = await _incomeService.GetIncomesByMonthAsync(month);
                return Ok(incomes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = $"An error occurred while retrieving incomes for month {month}.", error = ex.Message });
            }
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> SaveAllIncomes([FromBody] List<IncomeDto> incomes)
        {
            if (incomes == null || !incomes.Any())
            {
                return BadRequest("Incomes cannot be null or empty.");
            }

            try
            {
                await _incomeService.SaveAllIncomesAsync(incomes);
                return Ok(new { message = "All incomes saved successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "An error occurred while saving bulk incomes.", error = ex.Message });
            }
        }
    }
}
