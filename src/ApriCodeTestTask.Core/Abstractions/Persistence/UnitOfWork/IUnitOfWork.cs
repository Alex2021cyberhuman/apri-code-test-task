using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;

namespace ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGamesRepository Games { get; }

        IGenresRepository Genres { get; }

        IDevelopersRepository Developers { get; }
    }
}