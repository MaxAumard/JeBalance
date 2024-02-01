using System.Text.Json.Serialization;

namespace JeBalance.Administration.Ressources
{
    public class PaginationOutput <T>
    {
        [JsonPropertyName("result")]
        public IEnumerable<T> Results { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        public PaginationOutput(IEnumerable<T> results, int total)
        {
            Results = results;
            Total = total;
        }
    }
}
