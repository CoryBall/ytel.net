using System.Text.Json.Serialization;

namespace Ytel.Inbound
{
    public class InboundCallRequest : MakeCallUrlRequest
    {
        [JsonPropertyName("carrier")]
        public string? Carrier { get; set; }
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("wireless")]
        public bool? Wireless { get; set; }
        [JsonPropertyName("zipcode")]
        public string? Zipcode { get; set; }
    }
}
