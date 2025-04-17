namespace SweetCakeFrontend.DTO
{
    public class OrderCreateRequest
    {
        public int AccountId { get; set; }
        public int AddressId { get; set; }
        public string PaymentMode { get; set; } // "VNPay" hoặc "COD"
        public List<CartDto> Carts { get; set; }
    }
}
