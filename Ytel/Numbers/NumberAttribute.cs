using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum NumberAttribute
{
    [JsonPropertyName("voice-enabled")]
    Voice = 0,
    [JsonPropertyName("sms-enabled")]
    Sms = 1,
    [JsonPropertyName("mms-enabled")]
    Mms = 2
}