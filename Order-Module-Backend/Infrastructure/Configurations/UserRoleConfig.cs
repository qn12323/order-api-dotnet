using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("user_role_id").HasColumnType("int");
            builder.Property(x => x.UserId).HasColumnName("user_id").HasColumnType("int");
            builder.Property(x => x.RoleId).HasColumnName("role_id").HasColumnType("int");

            builder.ToTable("UserRole");
        }
    }
}
