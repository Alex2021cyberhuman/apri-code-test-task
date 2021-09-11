using ApriCodeTestTask.BusinessLogic.Shared.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ApriCodeTestTask.Api.Extensions
{
    public static class ValidationRegistrationServiceCollectionExtensions
    {
        public static IServiceCollection AddValidation(
            this IServiceCollection services)
        {
            ValidatorOptions.Global.LanguageManager.Enabled = false;
            return services.AddValidatorsFromAssembly(typeof(SharedValidator<>)
                    .Assembly, ServiceLifetime.Transient)
                .AddTransient(typeof(SharedValidator<>));
        }
    }
}