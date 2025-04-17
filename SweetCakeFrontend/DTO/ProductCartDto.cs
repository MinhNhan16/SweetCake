namespace SweetCakeFrontend.DTO
{
    public class ProductCartDto
    {
        public int CartId { get; set; }               // Mã giỏ hàng (Cart.Id)
        public int Quantity { get; set; }             // Số lượng
        public int SizeId { get; set; }               // Mã kích cỡ
        public string? SizeName { get; set; }         // Tên kích cỡ (nếu cần hiển thị)
        public decimal UnitPrice { get; set; }        // Giá mỗi đơn vị tại thời điểm thêm vào giỏ
        public decimal TotalPrice => UnitPrice * Quantity; // Tổng giá
        public string? PaymentMode { get; set; }      // Phương thức thanh toán (nếu đã chọn)
        public int ProductId { get; set; }            // Mã sản phẩm
        public string ProductName { get; set; }       // Tên sản phẩm
        public string Description { get; set; }       // Mô tả
        public string ImagePath { get; set; }         // Hình ảnh
        public int Stock { get; set; }                // Tồn kho}           // Mã danh mục
    }
}
