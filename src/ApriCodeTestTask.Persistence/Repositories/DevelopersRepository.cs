using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Persistence.DbContexts;

namespace ApriCodeTestTask.Persistence.Repositories
{
    public class DevelopersRepository : RepositoryBase<Developer>,
        IDevelopersRepository
    {
        public DevelopersRepository(ApplicationDbContext context) : base(
            context)
        {
        }
    }
}