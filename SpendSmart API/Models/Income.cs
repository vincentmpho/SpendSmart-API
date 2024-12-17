using System.ComponentModel.DataAnnotations;

namespace SpendSmart_API.Models
{
    public class Income
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Month is required.")]
        [MaxLength(20, ErrorMessage = "Month name cannot exceed 20 characters.")]
        public string Month { get; set; } = string.Empty; 

        [Required(ErrorMessage = "Source is required.")]
        [MaxLength(100, ErrorMessage = "Source cannot exceed 100 characters.")]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; } 

        [MaxLength(200, ErrorMessage = "Investments detail cannot exceed 200 characters.")]
        public string? Investments { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 
    }
}
