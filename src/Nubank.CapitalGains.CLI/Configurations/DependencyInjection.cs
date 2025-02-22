using Microsoft.Extensions.DependencyInjection;
using Nubank.CapitalGains.CLI.Implementations.Handlers;
using Nubank.CapitalGains.CLI.Implementations.Services;
using Nubank.CapitalGains.CLI.Interfaces.Services;

namespace Nubank.CapitalGains.CLI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {

            services.AddSingleton<IJsonService, JsonService>();
            services.AddTransient<ICalculateService, CalculateService>();   

            services.AddSingleton<OperationHandlerFactory>();
            services.AddTransient<BuyOperationHandler>();
            services.AddTransient<SellOperationHandler>();

            services.AddSingleton<Application>();

            return services;
        }
    }
}
