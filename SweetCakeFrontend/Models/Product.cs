namespace SweetCakeFrontend.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }

        public virtual ICollection<CartDetail> CartDetails { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductQuantities> ProductQuantities { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}