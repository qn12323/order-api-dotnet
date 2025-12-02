namespace Domain.Entities
{
    public class Payment : BaseEntity<int>
    {
        public string OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
