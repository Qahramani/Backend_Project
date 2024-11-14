using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services.Abstraction;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModel();
}
