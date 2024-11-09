using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class TagManager : EfCoreRepository<Tag>, ITagRepository
{
    public TagManager(AppDbContext dbContext) : base(dbContext)
    {
    }
}
