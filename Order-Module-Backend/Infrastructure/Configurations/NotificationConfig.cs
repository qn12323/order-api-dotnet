using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("notification_id").HasColumnType("int");
            builder.Property(x => x.UserId).HasColumnName("user_id").HasColumnType("int");
            builder.Property(x => x.OrderId).HasColumnName("order_id").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Message).HasColumnName("message").HasColumnType("nvarchar(500)");
            builder.Property(x => x.IsRead).HasColumnName("is_read").HasColumnType("bit");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");

            // get order and user

            builder.ToTable("Notification");
        }
    }
}
