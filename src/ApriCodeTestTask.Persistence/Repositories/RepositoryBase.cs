using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.Models;
using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApriCodeTestTask.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            var entry = _context.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entry.Entity;
        }

        public async Task<T> UpdateAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            var entry = _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entry.Entity;
        }

        public async Task RemoveAsync(T entity,
            CancellationToken cancellationToken = default)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> FindByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var entity = await Queryable
                .FirstOrDefaultAsync(e => e.Id == id,
                    cancellationToken);
            return entity;
        }

        public async Task<List<T>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            var items = await Queryable
                .ToListAsync(cancellationToken);
            return items;
        }

        protected virtual IQueryable<T> Queryable =>
            _context.Set<T>().AsNoTracking();
    }
}