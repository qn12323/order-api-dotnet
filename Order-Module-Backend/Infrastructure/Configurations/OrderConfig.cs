using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("order_id").HasMaxLength(20);
            builder.Property(x => x.UserId).HasColumnName("user_id").HasColumnType("int");
            builder.Property(x => x.OrderStatus).HasColumnName("order_status").HasColumnType("nvarchar(50)");
            builder.Property(x => x.TotalAmount).HasColumnName("total_amount").HasColumnType("decimal(18,2)");
            builder.Property(x => x.PaymentStatus).HasColumnName("payment_status").HasColumnType("nvarchar(50)");
            builder.Property(x => x.ShippingAddress).HasColumnName("shipping_address").HasColumnType("nvarchar(255)");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime");

            builder.HasMany(p => p.Items)
                .WithOne(v => v.Order)
                .HasForeignKey(v => v.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pv => pv.User)
                .WithMany()
                .HasForeignKey(pv => pv.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Order");
        }
    }
}
