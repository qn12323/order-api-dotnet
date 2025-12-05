using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("role_id").HasColumnType("int");
            builder.Property(x => x.RoleName).HasColumnName("role_name").HasColumnType("nvarchar(50)");

            builder.ToTable("Role");
        }
    }
}
