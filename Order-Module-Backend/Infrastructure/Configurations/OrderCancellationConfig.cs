using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderCancellationConfig : IEntityTypeConfiguration<OrderCancellation>
    {
        public void Configure(EntityTypeBuilder<OrderCancellation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cancellation_id").HasColumnType("int");
            builder.Property(x => x.CancelledBy).HasColumnName("cancelled_by").HasColumnType("int");
            builder.Property(x => x.OrderId).HasColumnName("order_id").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Reason).HasColumnName("reason").HasColumnType("nvarchar(500)");
            builder.Property(x => x.CancelledAt).HasColumnName("cancelled_at").HasColumnType("datetime");

            builder.HasOne(pv => pv.Order)
                .WithMany()
                .HasForeignKey(pv => pv.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("OrderCancellation");
        }
    }
}
