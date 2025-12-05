using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("product_id").HasColumnType("int");
            builder.Property(x => x.ProductName).HasColumnName("product_name").HasColumnType("nvarchar(255)");
            builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(18,2)");
            builder.Property(x => x.QuantityStock).HasColumnName("quantity_in_stock").HasColumnType("int");
            builder.Property(x => x.Description).HasColumnName("description").HasColumnType("nvarchar(500)");
            builder.Property(x => x.IsActived).HasColumnName("is_active").HasColumnType("bit");
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("datetime");

            builder.ToTable("Product");
        }
    }
}
