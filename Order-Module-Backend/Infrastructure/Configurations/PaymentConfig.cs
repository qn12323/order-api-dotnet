using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("payment_id").HasColumnType("int");
            builder.Property(x => x.OrderId).HasColumnName("order_id").HasColumnType("nvarchar(20)");
            builder.Property(x => x.PaymentMethod).HasColumnName("payment_method").HasColumnType("nvarchar(50)");
            builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(18,2)");
            builder.Property(x => x.PaymentStatus).HasColumnName("payment_status").HasColumnType("nvarchar(50)");
            builder.Property(x => x.PaidAt).HasColumnName("paid_at").HasColumnType("datetime");

            builder.HasOne(pv => pv.Order)
                .WithMany()
                .HasForeignKey(pv => pv.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Payment");
        }
    }
}
