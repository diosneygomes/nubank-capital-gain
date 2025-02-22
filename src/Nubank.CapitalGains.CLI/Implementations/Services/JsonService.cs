using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Interfaces.Services;
using Nubank.CapitalGains.CLI.Utils;
using System.Text;
using System.Text.Json;

namespace Nubank.CapitalGains.CLI.Implementations.Services
{
    public class JsonService : IJsonService
    {
        public async Task<IEnumerable<Operation>> DeserializeOperationsAsync(string input)
        {
            try
            {
                var isValid = InputValidator.Validate(input);

                if (!isValid)
                {
                    throw new ArgumentNullException(nameof(input), "Input string cannot be null or empty.");
                }

                var operationJson = await GetJsonAsync(input);

                var operations = operationJson.Select(opj => new Operation(opj));

                return operations;
            }
            catch (Exception e)
            {
                throw new JsonException($"An error occurred while deserializing the input - error message: {e.Message}");
            }
        }

        public string SerializeTaxes(IEnumerable<Tax> taxes)
        {
            var jsonTaxes = JsonSerializer.Serialize(taxes.Select(t => new { tax = t.TaxPaid }));

            return jsonTaxes;
        }

        private static async Task<IEnumerable<OperationJson>> GetJsonAsync(string input)
        {
            var inputStream = new MemoryStream(Encoding.UTF8.GetBytes(input));

            var json = await JsonDocument.ParseAsync(inputStream);

            var operationJson = json.Deserialize<IEnumerable<OperationJson>>();

            return operationJson ?? throw new JsonException("Invalid JSON.");
        }
    }
}
