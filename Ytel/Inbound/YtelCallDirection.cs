using System.Text.Json.Serialization;

namespace Ytel.Inbound;

public enum YtelCallDirection
{
    [JsonPropertyName("inbound")]
    Inbound,
    [JsonPropertyName("outbound")]
    Outbound,
}