using System.Threading.Tasks;
using ApriCodeTestTask.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApriCodeTestTask.Api.Extensions
{
    public static class HostExtensions
    {
        public static async Task<T> UpdateDatabaseAsync<T>(this T host) where T : IHost
        {
            await using var scope = host.Services.CreateAsyncScope();
            await using var context =
                scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            return host;
        }
    }
}