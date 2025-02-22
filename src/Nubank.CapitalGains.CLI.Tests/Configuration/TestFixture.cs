using Microsoft.Extensions.DependencyInjection;
using Nubank.CapitalGains.CLI.Configurations;
using Nubank.CapitalGains.CLI.Implementations.Handlers;

namespace Nubank.CapitalGains.CLI.Tests.Configuration
{
    public class TestFixture
    {
        public OperationHandlerFactory HandlerFactory { get; }

        public TestFixture()
        {
            var services = new ServiceCollection();
            services.AddDependency();
            var serviceProvider = services.BuildServiceProvider();

            HandlerFactory = serviceProvider.GetService<OperationHandlerFactory>();
        }
    }
}
