using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class OrderReturnConfig : IEntityTypeConfiguration<OrderReturn>
    {
        public void Configure(EntityTypeBuilder<OrderReturn> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("order_return_id").HasColumnType("int");
            builder.Property(x => x.Reason).HasColumnName("reason").HasColumnType("nvarchar(500)");
            builder.Property(x => x.OrderId).HasColumnName("order_id").HasColumnType("nvarchar(20)");
            builder.Property(x => x.Status).HasColumnName("status").HasColumnType("nvarchar(50)");
            builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");

            builder.HasOne(pv => pv.Order)
                .WithMany()
                .HasForeignKey(pv => pv.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("OrderReturn");
        }
    }
}
