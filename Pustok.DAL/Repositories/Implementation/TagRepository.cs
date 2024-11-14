using Pustok.DAL.DataContext;
using Pustok.DAL.Repositories.Abstraction;
using Pustok.DAL.Repositories.Implementation.Generic;

namespace Pustok.DAL.Repositories.Implementation;

public class TagRepository : EfCoreRepository<Tag>, ITagRepository
{
    public TagRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}
