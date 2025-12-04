namespace Domain.Entities
{
    public class OrderCancellation : BaseEntity<int>
    {
        public string OrderId { get; set; }
        public int CancelledBy { get; set; }
        public string Reason { get; set; }
        public DateTime CancelledAt { get; set; }
        public Order Order { get; set; }
    }
}
