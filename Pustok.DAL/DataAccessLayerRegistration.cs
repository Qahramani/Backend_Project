using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pustok.DAL.DataContext;
using System.Runtime.CompilerServices;

namespace Pustok.DAL;

public static class DataAccessLayerRegistration
{
    public static IServiceCollection AddDalServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });


        return services;
    }
}
