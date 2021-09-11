using System.Reflection;
using ApriCodeTestTask.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApriCodeTestTask.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Developer> Developers => Set<Developer>();

        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
        }
    }
}