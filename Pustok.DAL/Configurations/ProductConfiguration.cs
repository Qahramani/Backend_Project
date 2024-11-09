using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);
        builder.Property(x => x.OriginalPrice).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.DiscountPrice).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.Tax).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.ProductCode).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Color).IsRequired().HasMaxLength(30);
        builder.Property(x => x.InStock).HasDefaultValue(false);
        builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        builder.Property(x => x.StockQuantity).HasDefaultValue(0);
        builder.Property(x => x.Rating).HasDefaultValue(0);
        builder.Property(x => x.RewardPoint).HasDefaultValue(0);
    }
}
