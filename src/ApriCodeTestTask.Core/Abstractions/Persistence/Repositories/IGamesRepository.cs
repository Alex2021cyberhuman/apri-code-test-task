using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Entities;

namespace ApriCodeTestTask.Core.Abstractions.Persistence.Repositories
{
    public interface IGamesRepository : IRepository<Game>
    {
        Task<List<Game>> GetByGenreIdAsync(Guid genreId,
            CancellationToken cancellationToken = default);
    }
}