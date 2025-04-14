namespace SweetCakeFrontend.Models
{
    public class CartDetail
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
