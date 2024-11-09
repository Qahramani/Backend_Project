using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Link).IsRequired();
    }
}
