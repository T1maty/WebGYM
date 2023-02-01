using System.Text.Json.Serialization;

namespace WebGYM.Models.NpModels
{
    public class NovaPoshtaDataDto
    {
        [JsonPropertyName("data")]
        public List<NpResult>? Data { get; set; }
    }
}
