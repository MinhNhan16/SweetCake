namespace SweetCakeFrontend.Models
{
    public class Address
    {
        public int Id { get; set; } // Mã địa chỉ (PK)
        public string Street { get; set; } // Đường phố
        public string City { get; set; } // Thành phố
        public string State { get; set; } // Tỉnh
        public string Country { get; set; } // Quốc gia
        public int AccountId { get; set; } // Mã người dùng (FK)
        public Account Account { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
