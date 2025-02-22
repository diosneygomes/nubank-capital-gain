using Nubank.CapitalGains.CLI.Configurations;
using Nubank.CapitalGains.CLI.Enums;

namespace Nubank.CapitalGains.CLI.Entities
{
    public class Operation
    {
        public Operation(OperationJson operationJson)
        {
            Validation(operationJson);

            OperationType = (OperationType)Enum.Parse(typeof(OperationType), operationJson.OperationType, true);
            UnitCost = operationJson.UnitCost;
            Quantity = operationJson.Quantity;
        }

        public OperationType OperationType { get; }

        public decimal UnitCost { get; }

        public int Quantity { get; }

        private static void Validation(OperationJson operationJson)
        {
            if (!string.Equals(operationJson.OperationType.ToLower(), JsonOperationType.Buy)
                && !string.Equals(operationJson.OperationType.ToLower(), JsonOperationType.Sell))
            {
                throw new NotSupportedException($"Operation type is not supported: {operationJson.OperationType}");
            }
        }
    }
}
