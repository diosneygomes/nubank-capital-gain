using Nubank.CapitalGains.CLI.Configurations;
using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Implementations.Handlers;

namespace Nubank.CapitalGains.CLI.Tests.Operations
{
    public class BusinessRules
    {
        [Fact]
        public void ShouldCalculate20PercentTaxOnProfit()
        {
            var context = new OperationContext(averageCost: 10.00m, totalQuantity: 1000, accumulatedLoss: 0.00m);
            
            var operation = new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 50.00m, Quantity = 500 });
           
            var handler = new SellOperationHandler();

            var tax = handler.Execute(operation, context);

            Assert.Equal(4000.00m, tax.TaxPaid);
        }

        [Fact]
        public void ShouldUpdateAverageCostAfterBuy()
        {
            var context = new OperationContext(averageCost: 10.00m, totalQuantity: 1000, accumulatedLoss: 0.00m);
            
            var operation = new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 20.00m, Quantity = 500 });
            
            var handler = new BuyOperationHandler();

            var result = handler.Execute(operation, context);

            Assert.Equal(13.33m, result.UpdatedContext.AverageCost);
        }

        [Fact]
        public void ShouldAccumulateLossWhenSellingBelowAverageCost()
        {
            var context = new OperationContext(averageCost: 10.00m, totalQuantity: 1000, accumulatedLoss: 0.00m);
           
            var operation = new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 5.00m, Quantity = 500 });
           
            var handler = new SellOperationHandler();

            var tax = handler.Execute(operation, context);

            Assert.Equal(0.00m, tax.TaxPaid);
            
            Assert.Equal(2500.00m, tax.UpdatedContext.AccumulatedLoss);
        }

        [Fact]
        public void ShouldApplyExemptionForSalesBelow20000()
        {
            var context = new OperationContext(averageCost: 10.00m, totalQuantity: 1000, accumulatedLoss: 0.00m);
           
            var operation = new Operation(new OperationJson { OperationType = JsonOperationType.Sell, UnitCost = 20.00m, Quantity = 500 });
            
            var handler = new SellOperationHandler();

            var tax = handler.Execute(operation, context);

            Assert.Equal(0.00m, tax.TaxPaid);
        }

        [Fact]
        public void ShouldNotTaxBuyOperations()
        {
            var context = new OperationContext(averageCost: 10.00m, totalQuantity: 1000, accumulatedLoss: 0.00m);
            
            var operation = new Operation(new OperationJson { OperationType = JsonOperationType.Buy, UnitCost = 20.00m, Quantity = 500 });
            
            var handler = new BuyOperationHandler();

            var tax = handler.Execute(operation, context);

            Assert.Equal(0.00m, tax.TaxPaid);
        }
    }
}
