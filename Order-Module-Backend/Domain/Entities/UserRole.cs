namespace Domain.Entities
{
    public class UserRole : BaseEntity<int>
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
    }
}
