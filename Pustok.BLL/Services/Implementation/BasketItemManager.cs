using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class BasketItemManager : CrudManager<BasketItem, BasketItemViewModel, BasketItemListViewModel, BasketItemCreateViewModel, BasketItemUpdateViewModel>, IBasketItemService
{
    public BasketItemManager(IRepository<BasketItem> repository, IMapper mapper) : base(repository, mapper)
    {
    }

     
}

