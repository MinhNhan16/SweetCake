using System.ComponentModel.DataAnnotations;

namespace SweetCakeFrontend.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Đặt hàng")]
        Placed = 0,
        [Display(Name = "Đã xác nhận")]
        Confirmed = 1,
        [Display(Name = "Đang giao")]
        Shipping = 2,
        [Display(Name = "Đã giao")]
        Delivered = 3,
        [Display(Name = "Đã hủy")]
        Cancelled = 4
    }
}
