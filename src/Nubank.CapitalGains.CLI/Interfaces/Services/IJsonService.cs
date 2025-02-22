using Nubank.CapitalGains.CLI.Entities;

namespace Nubank.CapitalGains.CLI.Interfaces.Services
{
    public interface IJsonService
    {
        Task<IEnumerable<Operation>> DeserializeOperationsAsync(string input);

        string SerializeTaxes(IEnumerable<Tax> taxes);
    }
}
