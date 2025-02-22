using Nubank.CapitalGains.CLI.Entities;

namespace Nubank.CapitalGains.CLI.Interfaces.Handlers
{
    public interface IOperationHandler
    {
        Tax Execute(Operation operation, OperationContext context);
    }
}
