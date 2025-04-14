namespace SweetCakeFrontend.Models
{
    public class CartItem
    {

        public int Id { get; set; } // Mã giỏ hàng (PK)
        public int AccountId { get; set; } // Mã người dùng (FK)
        public Account Account { get; set; }

    }
}
