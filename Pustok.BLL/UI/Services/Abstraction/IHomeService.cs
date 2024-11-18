using Pustok.BLL.UI.ViewModels;

namespace Pustok.BLL.UI.Services.Abstraction;

public interface IHomeService
{
    Task<HomeViewModel> GetHomeViewModel(int? categoryId);
    Task<List<ProductViewModel>> GetProductsByCategory(int categoryId);
    Task<ProductDetailsViewModel> GetProductDetailsAsync(int id);
}
