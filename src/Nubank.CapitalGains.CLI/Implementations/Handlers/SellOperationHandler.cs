using Nubank.CapitalGains.CLI.Configurations;
using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Interfaces.Handlers;

namespace Nubank.CapitalGains.CLI.Implementations.Handlers
{
    public class SellOperationHandler : IOperationHandler
    {
        public Tax Execute(Operation operation, OperationContext context)
        {
            decimal totalSaleValue = operation.UnitCost * operation.Quantity;

            if (totalSaleValue <= TaxSettings.ExemptionLimit)
            {
                decimal loss = (context.AverageCost - operation.UnitCost) * operation.Quantity;
                context = context.Update(
                    accumulatedLoss: context.AccumulatedLoss + Math.Max(0, loss),
                    totalQuantity: context.TotalQuantity - operation.Quantity
                );
                return new Tax(context, 0);
            }

            decimal profit = (operation.UnitCost - context.AverageCost) * operation.Quantity;

            decimal deductibleLoss = Math.Min(context.AccumulatedLoss, profit);
            profit -= deductibleLoss;

            context = context.Update(
                accumulatedLoss: context.AccumulatedLoss - deductibleLoss,
                totalQuantity: context.TotalQuantity - operation.Quantity
            );

            decimal tax = profit > 0 ? Math.Round(profit * 0.20m, 2) : 0;

            return new Tax(context, tax);
        }
    }
}
