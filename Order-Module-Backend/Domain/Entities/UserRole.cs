namespace Domain.Entities
{
    public class UserRole : BaseEntity<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
