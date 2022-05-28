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
        [JsonPropertyName("payload")]
        public List<T>? Payload { get; set; }
        [JsonPropertyName("error")]
        public List<YtelApiError>? Error { get; set; }

        public YtelApiResponse()
        {
        }
    }
}