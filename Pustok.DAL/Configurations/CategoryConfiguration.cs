using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pustok.DAL.Configurations;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        builder.Property(x => x.ParentCategoryId).IsRequired(false);
        builder.HasOne(c => c.ParentCategory)
       .WithMany(c => c.SubCategories)
       .HasForeignKey(c => c.ParentCategoryId)
       .OnDelete(DeleteBehavior.Restrict);
    }
}
