using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class SubscribeManager : CrudManager<Subscribe, SubscribeViewModel, SubscribeListViewModel, SubscribeCreateViewModel, SubscribeUpdateViewModel>, ISubscribeService
{
    public SubscribeManager(IRepository<Subscribe> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
