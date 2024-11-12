using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class SettingManager : CrudManager<Setting, SettingViewModel, SettingListViewModel, SettingCreateViewModel, SettingUpdateViewModel>, ISettingService
{
    public SettingManager(IRepository<Setting> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}