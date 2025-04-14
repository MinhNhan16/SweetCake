namespace SweetCakeFrontend.Models
{
    public class ProductQuantities
    {
        public int Id { get; set; } // Mã thực thể (PK)
        public int ProductId { get; set; } // Mã sản phẩm (FK)
        public Product Product { get; set; }
        public int SizeId { get; set; } // Mã kích cỡ (FK)
        public ProductSize Size { get; set; }
        public int ColorId { get; set; } // Mã màu (FK)
        public ProductColor Color { get; set; }
    }
}
