using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pustok.DAL.Configurations;
using System.Reflection;

namespace Pustok.DAL.DataContext;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        base.OnModelCreating(builder);
    }

    public DbSet<BasketItem> BasketItems { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<Subscribe> Subscribes { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<ProductImage> ProductImages { get; set; } = null!;


    public DbSet<ProductTag> ProductTags { get; set; } = null!;

}
