namespace Domain.Entities
{
    public class Notification : BaseEntity<int>
    {
        public int UserId { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
