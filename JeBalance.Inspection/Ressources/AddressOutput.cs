using System.Text.Json.Serialization;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Inspection.Ressources
{
    public class AddressOutput
    {
        [JsonPropertyName("number")]
        public int Number { get; }
        [JsonPropertyName("streetName")]
        public string StreetName { get; }
        [JsonPropertyName("postCode")]
        public int PostalCode { get; }
        [JsonPropertyName("city")]
        public string City { get; }

        public AddressOutput(Address address)
        {
            Number = address.Number;
            StreetName = address.StreetName;
            City = address.City;
            PostalCode = address.PostalCode;
        }
    }
}
