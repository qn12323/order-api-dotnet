namespace Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string HashPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedAd { get; set; }
    }
}
