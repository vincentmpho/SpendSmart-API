namespace SpendSmart_API.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
    }
}
