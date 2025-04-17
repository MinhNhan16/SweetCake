using SweetCakeFrontend.Models;

namespace SweetCakeFrontend.DTO
{
    public class OrderDetailDto
    {
        public string Id { get; set; } // Mã đơn hàng (PK)
        public int Quantity { get; set; } // Số lượng
        public int Size { get; set; } // Kích cỡ
        public decimal Price { get; set; } // Giá
        public float TotalPrice { get; set; } // Tổng giá

        public string OrderId { get; set; } // Mã đơn hàng (FK từ Order)
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
