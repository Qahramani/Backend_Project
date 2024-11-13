namespace Pustok.BLL.Services.Abstraction;

public interface IProductService : ICrudService<Product, ProductViewModel, ProductListViewModel, ProductCreateViewModel, ProductUpdateViewModel>
{
    Task<ProductCreateViewModel> GetProductCreateViewModelAsync();
    Task<ProductUpdateViewModel> GetProductUpdateViewModelAsync(int id);
    Task<ProductViewModel> GetProductDetailsViewModel(int id);
    Task ProductSoftDeleteAsync(int id);
}
