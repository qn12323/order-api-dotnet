using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("user_id").HasColumnType("int");
            builder.Property(x => x.UserName).HasColumnName("username").HasColumnType("nvarchar(50)");
            builder.Property(x => x.HashPassword).HasColumnName("password_hash").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("nvarchar(255)");
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").HasColumnType("nvarchar(20)");
            builder.Property(x => x.FullName).HasColumnName("full_name").HasColumnType("nvarchar(100)");
            builder.Property(x => x.IsActived).HasColumnName("is_active").HasColumnType("bit");
            builder.Property(x => x.CreatedAd).HasColumnName("created_at").HasColumnType("datetime");

            builder.ToTable("User");
        }
    }
}
