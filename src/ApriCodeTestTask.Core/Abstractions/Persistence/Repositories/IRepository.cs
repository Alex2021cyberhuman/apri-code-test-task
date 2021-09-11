using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.Models;

namespace ApriCodeTestTask.Core.Abstractions.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<TEntity> AddAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity,
            CancellationToken cancellationToken = default);

        Task<TEntity?> FindByIdAsync(Guid id,
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(
            CancellationToken cancellationToken = default);
    }
}