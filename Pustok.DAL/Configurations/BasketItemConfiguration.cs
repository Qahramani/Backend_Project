using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

internal class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
{
    public void Configure(EntityTypeBuilder<BasketItem> builder)
    {
        builder.Property(x => x.Count).HasDefaultValue(0);
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();
    }
}
