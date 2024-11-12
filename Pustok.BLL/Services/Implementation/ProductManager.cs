using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class ProductManager : CrudManager<Product, ProductViewModel, ProductListViewModel, ProductImageCreateViewModel, ProductImageUpdateViewModel>
{
    public ProductManager(IRepository<Product> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
