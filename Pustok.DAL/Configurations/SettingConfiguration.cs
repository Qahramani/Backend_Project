using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.Property(x => x.Key).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Value).IsRequired().HasMaxLength(255);
    }
}
