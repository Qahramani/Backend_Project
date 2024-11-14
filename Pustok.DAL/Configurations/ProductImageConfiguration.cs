using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.Property(x => x.IsMain).HasDefaultValue(false);
        builder.Property(x => x.IsHover).HasDefaultValue(false);
        builder.Property(x => x.ImageUrl).IsRequired();
    }
}
