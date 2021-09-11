using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApriCodeTestTask.Core.Abstractions.Persistence.Repositories;
using ApriCodeTestTask.Core.Abstractions.Persistence.UnitOfWork;
using ApriCodeTestTask.Persistence.DbContexts;
using ApriCodeTestTask.Persistence.Repositories;
using ApriCodeTestTask.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApriCodeTestTask.Api.Extensions
{
    public static class PersistenceRegistrationServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, string connectionString)
        {
            return services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseSqlServer(connectionString,
                        sqlOptions =>
                            sqlOptions.MigrationsAssembly(
                                "ApriCodeTestTask.Persistence.SqlServer"));
                })
                .Add(GetRepositoryTypes())
                .AddScoped<IUnitOfWork, EfUnitOfWork>()
                .AddValidation()
                .AddAutoMapper(Assembly.Load("ApriCodeTestTask.BusinessLogic"));
        }

        private static IEnumerable<ServiceDescriptor> GetRepositoryTypes()
        {
            return typeof(RepositoryBase<>).Assembly
                .GetTypes()
                .Where(type =>
                    !type.IsAbstract &&
                    type.IsClass &&
                    type.IsVisible &&
                    type.Name.EndsWith("Repository"))
                .SelectMany(type => type.GetInterfaces(),
                    (type, inter) =>
                        new ServiceDescriptor(inter, type,
                            ServiceLifetime.Scoped));
        }
    }
}