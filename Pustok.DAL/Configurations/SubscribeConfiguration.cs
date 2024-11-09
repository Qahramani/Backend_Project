using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
{
    public void Configure(EntityTypeBuilder<Subscribe> builder)
    {
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.IsActive).HasDefaultValue(true);
    }
}
