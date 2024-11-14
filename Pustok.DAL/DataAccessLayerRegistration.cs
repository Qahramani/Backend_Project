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

        services.AddScoped<IBasketItemRepository, BasketItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<ISubscribeRepository, SubscribeRepository>();
        services.AddScoped<ITagRepository, TagRepository>();

        services.AddScoped<DataInitializer>();

        return services;
    }
}
