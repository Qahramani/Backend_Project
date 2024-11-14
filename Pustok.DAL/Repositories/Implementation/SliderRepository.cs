using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class SliderRepository : EfCoreRepository<Slider>, ISliderRepository
{
    public SliderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}