using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(x => x.MainText).IsRequired().HasMaxLength(255);
        builder.Property(x => x.SubText).IsRequired().HasMaxLength(255);
        builder.Property(x => x.IconUrl).IsRequired();

    }
}
