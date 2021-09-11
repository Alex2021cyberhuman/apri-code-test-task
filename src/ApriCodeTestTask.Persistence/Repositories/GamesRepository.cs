using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using ApriCodeTestTask.Core.Entities;
using ApriCodeTestTask.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ApriCodeTestTask.Persistence.Repositories
{
    public class GamesRepository : RepositoryBase<Game>, IGamesRepository
    {
        private readonly ApplicationDbContext _context;

        public GamesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetByGenreIdAsync(Guid genreId,
            CancellationToken cancellationToken = default)
        {
            return await Queryable.Where(game =>
                    game.Genres.Any(genre => genre.Id == genreId))
                .ToListAsync(cancellationToken);
        }

        protected override IQueryable<Game> Queryable => _context.Games
            .AsNoTracking()
            .Include(game => game.Developer)
            .Include(game => game.Genres);
    }
}