using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class ProductTagManager : CrudManager<ProductTag, ProductTagViewModel, ProductTagListViewModel, ProductTagCreateViewModel, ProductTagUpdateViewModel>, IProductTagService
{
    public ProductTagManager(IRepository<ProductTag> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

