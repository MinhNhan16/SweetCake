namespace SweetCakeFrontend.DTO
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } // Tên sản phẩm
        public int Quantity { get; set; } // Số lượng sản phẩm
        public decimal TotalPrice { get; set; } // Tổng giá sản phẩm
    }
}
