using System;
using System.Text.Json.Serialization;
using Ytel.Call;

namespace Ytel.Inbound;

public class InboundCallRequest
{
    [JsonPropertyName("AccountSid")]
    public Guid AccountSid { get; set; }
    [JsonPropertyName("To")]
    public string To { get; set; } = null!;
    [JsonPropertyName("From")]
    public string From { get; set; } = null!;
    [JsonPropertyName("CallSid")]
    public Guid CallSid { get; set; }
    [JsonPropertyName("status")]
    public YtelCallStatus? Status { get; set; }
    [JsonPropertyName("urlBase")]
    public string? UrlBase { get; set; } = null!;
}