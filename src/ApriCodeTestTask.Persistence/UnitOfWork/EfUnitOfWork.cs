using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;

namespace ApriCodeTestTask.Persistence.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        public EfUnitOfWork(IGamesRepository games, IGenresRepository genres,
            IDevelopersRepository developers)
        {
            Games = games;
            Genres = genres;
            Developers = developers;
        }

        public IGamesRepository Games { get; }

        public IGenresRepository Genres { get; }

        public IDevelopersRepository Developers { get; }
    }
}