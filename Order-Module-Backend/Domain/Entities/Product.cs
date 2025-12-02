namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
        public string Description { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
