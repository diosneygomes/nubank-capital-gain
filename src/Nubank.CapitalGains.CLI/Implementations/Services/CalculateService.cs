using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Implementations.Handlers;
using Nubank.CapitalGains.CLI.Interfaces.Services;

namespace Nubank.CapitalGains.CLI.Implementations.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly OperationHandlerFactory _handlerFactory;

        public CalculateService(OperationHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public IEnumerable<Tax> CalculateCapitalGainsTaxes(IEnumerable<Operation> operations)
        {
            var context = new OperationContext();
            var taxes = new List<Tax>();

            foreach (var operation in operations)
            {
                var handler = _handlerFactory.GetHandler(operation.OperationType);
                var tax = handler.Execute(operation, context);
                context = tax.UpdatedContext;
                taxes.Add(tax);
            }

            return taxes;
        }
    }
}
