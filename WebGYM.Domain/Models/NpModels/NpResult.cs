using System.Text.Json.Serialization;

namespace WebGYM.Models.NpModels
{
    public class NpResult
    {
        [JsonPropertyName("Description")]
        public string Description { get; set; } = string.Empty;


        [JsonPropertyName("Ref")]
        public string Ref { get; set; } = string.Empty;
    }
}
