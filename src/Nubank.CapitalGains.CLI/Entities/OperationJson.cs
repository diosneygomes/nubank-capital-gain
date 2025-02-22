using System.Text.Json.Serialization;

namespace Nubank.CapitalGains.CLI.Entities
{
    public class OperationJson
    {
        [JsonPropertyName("operation")]
        public string OperationType { get; set; }

        [JsonPropertyName("unit-cost")]
        public decimal UnitCost { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
