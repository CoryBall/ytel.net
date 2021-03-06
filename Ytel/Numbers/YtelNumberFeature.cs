using System.Text.Json.Serialization;

namespace Ytel.Numbers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum YtelNumberFeature
{
    [JsonPropertyName("voice")]
    Voice = 0,
    [JsonPropertyName("voice")]
    Sms = 1,
    [JsonPropertyName("voice")]
    Mms = 2
}