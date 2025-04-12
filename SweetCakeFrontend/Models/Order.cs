namespace SweetCakeFrontend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public int? ShipperId { get; set; }
        public int? DiscountId { get; set; }
        public virtual Account Customer { get; set; }
        public virtual Account Shipper { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
