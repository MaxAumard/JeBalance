using System.Text.Json.Serialization;
using JeBalance.Domain.Models;

namespace JeBalance.Administration.Ressources
{
    public class PersonOutput
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("firstName")] public string FirstName { get; set; }
        [JsonPropertyName("lastName")] public string LastName { get; set; }
        [JsonPropertyName("address")] public AddressOutput Address { get; set; }
        [JsonPropertyName("isBanned")] public bool IsBanned { get; set; }
        [JsonPropertyName("isVIP")] public bool IsVIP { get; set; }

        public PersonOutput()
        {
        }

        public PersonOutput(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Address = new AddressOutput(person.Address);
            IsBanned = person.IsBanned;
            IsVIP = person.IsVIP;
        }
    }
}