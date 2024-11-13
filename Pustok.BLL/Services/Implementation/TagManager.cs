using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class TagManager : CrudManager<Tag, TagViewModel, TagListViewModel, TagCreateViewModel, TagUpdateViewModel>, ITagService
{
    public TagManager(IRepository<Tag> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

