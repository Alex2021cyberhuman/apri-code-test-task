using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ApriCodeTestTask.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApriCodeTestTask.Api.Extensions
{
    public static class BusinessLogicRegistrationServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(
            this IServiceCollection services)
        {
            return services.Add(GetServicesTypes());
        }

        private static IEnumerable<ServiceDescriptor> GetServicesTypes()
        {
            return Assembly.Load("ApriCodeTestTask.BusinessLogic")
                .GetTypes()
                .Where(type =>
                    !type.IsAbstract &&
                    type.IsClass &&
                    type.IsVisible &&
                    type.Name.EndsWith("Service"))
                .SelectMany(type => type.GetInterfaces(),
                    (type, inter) =>
                        new ServiceDescriptor(inter, type,
                            ServiceLifetime.Scoped));
        }
    }
}