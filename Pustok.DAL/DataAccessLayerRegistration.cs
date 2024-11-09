﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DAL.DataContext;
using Microsoft.AspNetCore.Identity;

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


        services.AddScoped<DataInitializer>();

        return services;
    }
}
