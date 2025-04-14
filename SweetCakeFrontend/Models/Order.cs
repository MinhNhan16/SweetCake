namespace SweetCakeFrontend.Models
{
    public class Order
    {
        public string Id { get; set; } // Mã đơn hàng (PK)
        public DateTime OrderDate { get; set; } // Ngày đặt hàng
        public decimal TotalPrice { get; set; } // Tổng giá
        public string PaymentMode { get; set; } // Phương thức thanh toán
        public int OrderStatus { get; set; } // Trạng thái đơn hàng
        public int AccountId { get; set; } // Mã người dùng (FK)
        public Account Account { get; set; }
        public int AddressId { get; set; } // Mã địa chỉ (FK)
        public Address Address { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
