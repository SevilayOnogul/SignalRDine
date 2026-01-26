using System.Text.Json.Serialization; // Bunu eklemeyi unutma

namespace SignalRDine.WebUI.Models
{
    public class ApiValidationErrorResponse
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("errors")]
        public Dictionary<string, List<string>> Errors { get; set; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; set; }
    }
}