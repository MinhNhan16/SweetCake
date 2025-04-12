namespace SweetCakeFrontend.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountValue { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
