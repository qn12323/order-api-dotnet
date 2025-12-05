using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("order_item_id").HasColumnType("int");
            builder.Property(x => x.OrderId).HasColumnName("order_id").HasColumnType("nvarchar(20)");
            builder.Property(x => x.ProductId).HasColumnName("product_id").HasColumnType("int");
            builder.Property(x => x.Quantity).HasColumnName("quantity").HasColumnType("int");
            builder.Property(x => x.UnitPrice).HasColumnName("unit_price").HasColumnType("decimal(18,2)");
            builder.Property(x => x.TotalPrice).HasColumnName("total_price").HasColumnType("decimal(18,2)");

            builder.HasOne(pv => pv.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(pv => pv.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pv => pv.Product)
                .WithMany()
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("OrderItem");
        }
    }
}
