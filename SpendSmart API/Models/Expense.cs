namespace SpendSmart_API.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public string ExpenseType { get; set; } 
        public decimal ExpenseAmount { get; set; }
    }
}
