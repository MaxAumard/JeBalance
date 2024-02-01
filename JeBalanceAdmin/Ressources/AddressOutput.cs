using System.Text.Json.Serialization;
using JeBalance.Domain.ValueObjects;

namespace JeBalance.Administration.Ressources
{
    public class AddressOutput
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }
        [JsonPropertyName("streetName")]
        public string StreetName { get; set; }
        [JsonPropertyName("postCode")]
        public int PostalCode { get;set; }
        [JsonPropertyName("city")]
        public string City { get;set; }

        public AddressOutput()
        {
        }
        public AddressOutput(Address address)
        {
            Number = address.Number;
            StreetName = address.StreetName;
            City = address.City;
            PostalCode = address.PostalCode;
        }
    }
}
