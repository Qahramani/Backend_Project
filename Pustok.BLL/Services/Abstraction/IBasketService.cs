
namespace Pustok.BLL.Services.Abstraction;

public interface IBasketService
{
    Task AddToBasketAsync(int id);
    Task<List<GetBasketViewModel>> ShoppingCardAsync();
}
