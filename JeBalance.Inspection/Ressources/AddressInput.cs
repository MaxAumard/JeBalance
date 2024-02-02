using System.Text.Json.Serialization;

namespace JeBalance.Inspection.Ressources
{
    public class AddressInput
    {
        [JsonPropertyName("number")] public int Number { get; set; }
        [JsonPropertyName("streetName")] public string StreetName { get; set; }
        [JsonPropertyName("postalCode")] public int PostalCode { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }

        public AddressInput()
        {
        }
    }
}