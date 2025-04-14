namespace SweetCakeFrontend.Models
{
    public class Notification
    {
        public Guid Id { get; set; } // Mã thông báo (PK)

        public DateTime Created { get; set; } // Ngày tạo thông báo

        public string Title { get; set; } // Tiêu đề thông báo

        public string Message { get; set; } // Nội dung thông báo

        public string DataUrl { get; set; } // URL khi nhấp vào thông báo

        public string Data { get; set; } // Object JSON dữ liệu kèm

        public bool IsRead { get; set; } // Thông báo đã đọc hay chưa

        public Guid AccountId { get; set; } // Mã người dùng (FK)
        public Account Account { get; set; }
    }
}
