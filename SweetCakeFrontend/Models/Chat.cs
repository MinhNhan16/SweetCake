namespace SweetCakeFrontend.Models
{
    public class Chat
    {

        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime SentDate { get; set; }
        public bool IsRead { get; set; } = false;
        public virtual Account Sender { get; set; }
        public virtual Account Receiver { get; set; }
    }
}
