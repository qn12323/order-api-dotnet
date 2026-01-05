namespace Domain.Entities
{
    public class Role : BaseEntity<int>
    {
        public string RoleName { get; set; }
        public bool IsActived { get; set; }
    }
}
