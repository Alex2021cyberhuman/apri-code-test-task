using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Persistence.DbContexts;

namespace ApriCodeTestTask.Persistence.Repositories
{
    public class GenresRepository : RepositoryBase<Genre>, IGenresRepository
    {
        public GenresRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}