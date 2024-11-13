using Pustok.BLL.Services.Abstraction;
using Pustok.BLL.Services.Implementation.Generic;
using Pustok.DAL.Repositories.Abstraction.Generic;

namespace Pustok.BLL.Services.Implementation;

public class SliderManager : CrudManager<Slider, SliderViewModel, SliderListViewModel, SliderCreateViewModel, SliderUpdateViewModel>, ISliderService
{
    public SliderManager(IRepository<Slider> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}

