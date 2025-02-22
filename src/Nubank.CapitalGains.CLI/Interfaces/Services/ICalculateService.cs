using Nubank.CapitalGains.CLI.Entities;

namespace Nubank.CapitalGains.CLI.Interfaces.Services
{
    public interface ICalculateService
    {
        IEnumerable<Tax> CalculateCapitalGainsTaxes(IEnumerable<Operation> operations);
    }
}
