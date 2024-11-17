using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pustok.BLL.Services.Implementation;
using Pustok.BLL.ViewModels.AccountViewModels;

namespace Pustok.BLL.Services.Abstraction;

public interface IAccountService
{
    Task<bool> LoginAsync(LoginViewModel loginVm, ModelStateDictionary modelState);
    Task<ServiceResponse> RegisetrAsync(RegisterViewModel registerVm, ModelStateDictionary modelState);
    Task<bool> LogoutAsync();
}
