using System.Text.Json.Serialization;

namespace Ytel.Call;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum IfMachine
{
    [JsonPropertyName("hangup")]
    Hangup = 0,
    [JsonPropertyName("continue")]
    Continue = 1
}