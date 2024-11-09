using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SliderManager : EfCoreRepository<Slider>, ISliderRepository
{
    public SliderManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}