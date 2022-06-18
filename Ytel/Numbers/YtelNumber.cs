using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using Ytel.Serialization;

namespace Ytel.Numbers;

public class YtelNumber
{
    [JsonPropertyName("accountSid")]
    public Guid AccountSid { get; set; }
    [JsonPropertyName("phoneSid")]
    public Guid PhoneSid { get; set; }
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = "";
    [JsonPropertyName(("cnam"))]
    public string? Cnam { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceUrl")]
    public string? VoiceUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceMethod")]
    public string? VoiceMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceFallbackUrl")]
    public string? VoiceFallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceFallbackMethod")]
    public string? VoiceFallbackMethod { get; set; }
    [JsonConverter(typeof(DateTimeTickJsonConverter))]
    [JsonPropertyName("renewalDate")]
    public DateTime RenewalDate { get; set;  }
    [JsonConverter(typeof(DateTimeTickJsonConverter))]
    [JsonPropertyName("purchaseDate")]
    public DateTime PurchaseDate { get; set; }
    [JsonPropertyName("region")]
    public string? Region { get; set; }
    [JsonPropertyName("timezone")]
    public int TimeZone { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsUrl")]
    public string? SmsUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsMethod")]
    public string? SmsMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsFallbackUrl")]
    public string? SmsFallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsFallbackMethod")]
    public string? SmsFallbackMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("heartbeatUrl")]
    public string? HeartbeatUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("heartbeatMethod")]
    public string? HeartbeatMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hangupCallbackUrl")]
    public string? HangupCallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hangupCallbackMethod")]
    public string? HangupCallbackMethod { get; set; }
    [JsonPropertyName("attributes")]
    public List<YtelNumberAttribute>? Attributes { get; set; }
    [JsonPropertyName("numberType")]
    public int NumberType { get; set; }

    public YtelNumber()
    {
    }
}