using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ytel
{
    public class YtelApiResponse<T> where T : class
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("page")]
        public int Page { get; set; }
        [JsonPropertyName("nextKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NextKey { get; set; }
        [JsonPropertyName("payload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<T>? Payload { get; set; }
        [JsonPropertyName("error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<YtelApiError>? Error { get; set; }
    }
}