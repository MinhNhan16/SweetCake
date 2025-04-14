namespace SweetCakeFrontend.Models
{
    public class Cart
    {
        public int Id { get; set; } // Mã giỏ hàng (PK)
        public int Quantity { get; set; } // Số lượng
        public int Size { get; set; } // Kích cỡ
        public int CheckoutCount { get; set; } // Số lượng bán
        public decimal Price { get; set; } // Giá
        public string PaymentMode { get; set; } // Phương thức thanh toán
        public DateTime DateCreated { get; set; } // Ngày tạo
        public decimal TotalPrice { get; set; } // Tổng giá
        public float PayPalPayment { get; set; } // Tổng tiền thanh toán PayPal
        public int AccountId { get; set; } // Mã người dùng (FK)
        public Account Account { get; set; }
        public int AddressId { get; set; } // Mã địa chỉ (FK)
        public Address Address { get; set; }
        public int SizeId { get; set; } // Mã kích cỡ (FK)
        public ProductSize ProductSize { get; set; }

        public int ProductId { get; set; } // Mã sản phẩm (FK)
        public Product Product { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
