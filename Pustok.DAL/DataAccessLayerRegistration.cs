using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DAL.DataContext;
using Microsoft.AspNetCore.Identity;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL;

public static class DataAccessLayerRegistration
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
            builder =>
                builder.MigrationsAssembly("Pustok.DAL")
        ));

        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 4;
            options.User.RequireUniqueEmail = true;

            options.Lockout.MaxFailedAccessAttempts = 7;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

        }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

        services.AddScoped(typeof(IRepository<>),typeof(EfCoreRepository<>));

        services.AddScoped<IBasketItemRepository, BasketItemManager>();
        services.AddScoped<ICategoryRepository, CategoryManager>();
        services.AddScoped<IProductRepository, ProductManager>();
        services.AddScoped<IProductImageRepository, ProductImageManager>();
        services.AddScoped<IServiceRepository, ServiceManager>();
        services.AddScoped<ISettingRepository, SettingManager>();
        services.AddScoped<ISliderRepository, SliderManager>();
        services.AddScoped<ISubscribeRepository, SubscribeManager>();
        services.AddScoped<ITagRepository, TagManager>();

        services.AddScoped<DataInitializer>();

        return services;
    }
}
