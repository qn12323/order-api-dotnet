namespace Domain.Entities
{
    public class OrderReturn : BaseEntity<int>
    {
        public string OrderId { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
