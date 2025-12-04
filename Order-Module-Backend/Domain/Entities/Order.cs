namespace Domain.Entities
{
    public class Order : BaseEntity<string>
    {
        public int UserId { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User User { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
