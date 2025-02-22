using Nubank.CapitalGains.CLI.Entities;
using Nubank.CapitalGains.CLI.Interfaces.Services;
using Nubank.CapitalGains.CLI.Utils;

namespace Nubank.CapitalGains.CLI
{
    public class Application
    {
        private readonly IJsonService _jsonService;
        private readonly ICalculateService _calculateService;

        public Application(IJsonService jsonService, ICalculateService calculateService)
        {
            _jsonService = jsonService;
            _calculateService = calculateService;
        }

        public async Task RunAsync()
        {
            string inputLine;

            while (InputValidator.Validate(inputLine = Console.ReadLine()))
            {
                try
                {
                    var operations = await _jsonService.DeserializeOperationsAsync(inputLine);
                    
                    var taxes = _calculateService.CalculateCapitalGainsTaxes(operations);

                    DisplayResults(taxes);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred during execution: {e.Message}");
                }
            }
        }

        private void DisplayResults(IEnumerable<Tax> results)
        {
            var serializedResults = _jsonService.SerializeTaxes(results);

            Console.WriteLine(serializedResults);
        }
    }
}
