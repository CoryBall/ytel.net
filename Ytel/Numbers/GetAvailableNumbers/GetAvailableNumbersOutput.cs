using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

public class GetAvailableNumbersOutput
{
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber { get; set; }
    [JsonPropertyName("region")]
    public string? Region { get; set; }
    [JsonPropertyName("timezone")]
    public int TimeZone { get; set; }
    [JsonPropertyName("attributes")]
    public List<NumberAttribute>? Attributes { get; set; }
    [JsonPropertyName("numberType")]
    public int NumberType { get; set; }

    public GetAvailableNumbersOutput()
    {
    }
}