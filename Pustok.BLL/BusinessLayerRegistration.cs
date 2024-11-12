using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation;
using Pustok.BLL.Services.Implementation.Generic;
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

        //services.AddFluentValidation(fv =>
        //{
        //    fv.RegisterValidatorsFromAssemblyContaining<CategoryPostViewModelValidator>();
        //    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
        //});

        services
             .AddFluentValidationAutoValidation()
             .AddFluentValidationClientsideAdapters()
             .AddValidatorsFromAssemblyContaining<CategoryPostViewModelValidator>();

        //services.AddFluentValidationAutoValidation()
        //        .AddFluentValidationClientsideAdapters()
        //        .AddValidatorsFromAssemblyContaining<CategoryPostViewModelValidator>();

        return services;
    }
}
