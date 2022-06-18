using System.Text.Json.Serialization;

namespace Ytel.Call;

[JsonConverter(typeof(JsonStringEnumMemberConverter))]
public enum YtelDialtone
{
    [JsonPropertyName("0")]
    Zero = 0,
    [JsonPropertyName("1")]
    One = 1,
    [JsonPropertyName("2")]
    Two = 2,
    [JsonPropertyName("3")]
    Three = 3,
    [JsonPropertyName("4")]
    Four = 4,
    [JsonPropertyName("5")]
    Five = 5,
    [JsonPropertyName("6")]
    Size = 6,
    [JsonPropertyName("7")]
    Seven = 7,
    [JsonPropertyName("8")]
    Eight = 8,
    [JsonPropertyName("9")]
    Nine = 9,
    [JsonPropertyName("*")]
    Star = 10,
    [JsonPropertyName("#")]
    Pound = 11,
}