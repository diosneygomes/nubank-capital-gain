using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Interfaces.Handlers;

namespace Nubank.CapitalGains.CLI.Implementations.Handlers
{
    public class BuyOperationHandler : IOperationHandler
    {
        public Tax Execute(Operation operation, OperationContext context)
        {
            var newAverageCost = Math.Round(
                (context.AverageCost * context.TotalQuantity + operation.Quantity * operation.UnitCost) /
                (context.TotalQuantity + operation.Quantity), 2);

            var newContext = context.Update(
                averageCost: newAverageCost,
                totalQuantity: context.TotalQuantity + operation.Quantity
            );

            return new Tax(newContext, 0);
        }
    }
}
