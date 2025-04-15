namespace SweetCakeFrontend.Models
{
    public class TopCustomer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalSpent { get; set; }
        public int OrderCount { get; set; }
    }
}
