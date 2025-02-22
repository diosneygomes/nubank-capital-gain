namespace Nubank.CapitalGains.CLI.Entities
{
    public class Tax
    {
        public Tax(OperationContext updatedContext, decimal taxPaid)
        {
            UpdatedContext = updatedContext;
            TaxPaid = taxPaid;
        }

        public OperationContext UpdatedContext { get; }

        public decimal TaxPaid { get; }
    }
}
