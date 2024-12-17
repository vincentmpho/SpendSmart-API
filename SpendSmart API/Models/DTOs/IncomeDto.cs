using System.ComponentModel.DataAnnotations;

namespace SpendSmart_API.Models.DTOs
{
    public class IncomeDto
    {
        [Required(ErrorMessage = "Month is required.")]
        public string Month { get; set; } = string.Empty;

        [Required(ErrorMessage = "Source is required.")]
        public string Source { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Investments are required.")]
        public string Investments { get; set; } = string.Empty;
    }
}
