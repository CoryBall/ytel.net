using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using Ytel.Serialization;

namespace Ytel.Numbers;

public class Number
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
    public Uri? VoiceUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceMethod")]
    public HttpMethod? VoiceMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceFallbackUrl")]
    public Uri? VoiceFallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("voiceFallbackMethod")]
    public HttpMethod? VoiceFallbackMethod { get; set; }
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
    public Uri? SmsUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsMethod")]
    public HttpMethod? SmsMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsFallbackUrl")]
    public Uri? SmsFallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("smsFallbackMethod")]
    public HttpMethod? SmsFallbackMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("heartbeatUrl")]
    public Uri? HeartbeatUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("heartbeatMethod")]
    public HttpMethod? HeartbeatMethod { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hangupCallbackUrl")]
    public Uri? HangupCallbackUrl { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("hangupCallbackMethod")]
    public HttpMethod? HangupCallbackMethod { get; set; }
    [JsonPropertyName("attributes")]
    public List<NumberAttribute>? Attributes { get; set; }
    [JsonPropertyName("numberType")]
    public int NumberType { get; set; }

    public Number()
    {
    }
}