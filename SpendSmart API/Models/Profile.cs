using System.ComponentModel.DataAnnotations;

namespace SpendSmart_API.Models
{
    public class Profile
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(18, int.MaxValue, ErrorMessage = "Age must be at least 18.")]
        public int Age { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Occupation { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Contact { get; set; }
    }
}
