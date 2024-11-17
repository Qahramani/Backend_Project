using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class ServiceManager : CrudManager<Service, ServiceViewModel, ServiceListViewModel, ServiceCreateViewModel, ServiceUpdateViewModel>, IServiceService
{
    public ServiceManager(IRepository<Service> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
