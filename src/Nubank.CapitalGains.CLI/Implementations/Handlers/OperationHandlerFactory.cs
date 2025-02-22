using Nubank.CapitalGains.CLI.Enums;
using Nubank.CapitalGains.CLI.Interfaces.Handlers;

namespace Nubank.CapitalGains.CLI.Implementations.Handlers
{
    public class OperationHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public OperationHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOperationHandler GetHandler(OperationType type)
        {
            return type switch
            {
                OperationType.Buy => _serviceProvider.GetService(typeof(BuyOperationHandler)) as IOperationHandler,
                OperationType.Sell => _serviceProvider.GetService(typeof(SellOperationHandler)) as IOperationHandler,
                _ => throw new NotSupportedException($"OperationType '{type}' is not supported.")
            };
        }
    }
}
