using System;
using System.Text.Json.Serialization;
using Ytel.Call;

namespace Ytel.Inbound;

public class MakeCallUrlRequest
{
    [JsonPropertyName("AccountSid")]
    public Guid AccountSid { get; set; }
    [JsonPropertyName("CallSid")]
    public Guid CallSid { get; set; }
    [JsonPropertyName("To")]
    public string? To { get; set; }
    [JsonPropertyName("From")]
    public string? From { get; set; }
}