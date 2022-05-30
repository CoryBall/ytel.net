using System;
using System.Text.Json.Serialization;
using Ytel.Serialization;

namespace Ytel.Call;

public class MakeCallOutput
{
    [JsonPropertyName("callSid")]
    public Guid CallSid { get; set; }
    [JsonConverter(typeof(DateTimeRfr2822JsonConverter))]
    [JsonPropertyName("createdTime")]
    public DateTime CreatedTime { get; set; }
}