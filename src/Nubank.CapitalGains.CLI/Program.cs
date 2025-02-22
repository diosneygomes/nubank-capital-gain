using Microsoft.Extensions.DependencyInjection;
using Nubank.CapitalGains.CLI;
using Nubank.CapitalGains.CLI.Configurations;

var serviceCollection = new ServiceCollection();

serviceCollection.AddDependency();

var serviceProvider = serviceCollection.BuildServiceProvider();

var runner = serviceProvider.GetRequiredService<Application>();

await runner.RunAsync();