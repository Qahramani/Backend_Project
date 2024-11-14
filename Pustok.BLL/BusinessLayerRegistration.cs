using CloudinaryDotNet;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pustok.BLL.Helpers;
using Pustok.BLL.Helpers.Contracts;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.BLL.UI.Services.Abstraction;
using Pustok.BLL.UI.Services.Implementation;
using Pustok.BLL.Validators.CategoryViewModelValidators;
using System.Reflection;

namespace Pustok.BLL;

public static class BusinessLayerRegistration
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped(typeof(ICrudService<,,,,>), typeof(CrudManager<,,,,>));
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ITagService, TagManager>();
        services.AddScoped<IProductTagService, ProductTagManager>();
        services.AddScoped<IServiceService, ServiceManager>();
        services.AddScoped<ISettingService, SettingManager>();
        services.AddScoped<ISubscribeService, SubscribeManager>();
        services.AddScoped<ISliderService, SliderManager>();

        services.AddScoped<IHomeService, HomeManager>();
        


        services.AddScoped<ICloudinaryService, CloudinaryManager>();

      
        services
             .AddFluentValidationAutoValidation()
             .AddFluentValidationClientsideAdapters()
             .AddValidatorsFromAssemblyContaining<CategoryCreateViewModelValidator>();

      
        return services;
    }
}
