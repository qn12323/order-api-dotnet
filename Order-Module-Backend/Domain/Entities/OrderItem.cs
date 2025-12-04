namespace Domain.Entities
{
    public class OrderItem : BaseEntity<int>
    {
        public string OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; } 
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
