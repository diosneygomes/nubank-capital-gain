namespace Nubank.CapitalGains.CLI.Entities
{
    public class OperationContext
    {
        public decimal AverageCost { get; }
        public int TotalQuantity { get; }
        public decimal AccumulatedLoss { get; }

        public OperationContext(decimal averageCost = 0, int totalQuantity = 0, decimal accumulatedLoss = 0)
        {
            AverageCost = averageCost;
            TotalQuantity = totalQuantity;
            AccumulatedLoss = accumulatedLoss;
        }

        public OperationContext Update(decimal? averageCost = null, int? totalQuantity = null, decimal? accumulatedLoss = null)
        {
            return new OperationContext(
                averageCost ?? this.AverageCost,
                totalQuantity ?? this.TotalQuantity,
                accumulatedLoss ?? this.AccumulatedLoss
            );
        }
    }
}
