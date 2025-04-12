namespace SweetCakeFrontend.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Account Customer { get; set; }

        public ICollection<CartDetail> CartDetails { get; set; }
    }
}
