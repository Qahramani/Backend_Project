using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x => x.ImageUrl).IsRequired();
        builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
        builder.Property(x => x.OriginalPrice).HasDefaultValue(0).HasColumnType("decimal(10,2)");
        builder.Property(x => x.DiscountPrice).HasDefaultValue(0).HasColumnType("decimal(10,2)");

    }
}
