using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

public class Number
{
    [JsonPropertyName("accountSid")]
    public Guid AccountSid { get; set; }
    [JsonPropertyName("phoneSid")]
    public Guid PhoneSide { get; set; }
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = "";
    [JsonPropertyName("voiceUrl")]
    public Uri? VoiceUrl { get; set; }
    [JsonPropertyName("voiceMethod")]
    public HttpMethod? VoiceMethod { get; set; }
    [JsonPropertyName("voiceFallbackUrl")]
    public Uri? VoiceFallbackUrl { get; set; }
    [JsonPropertyName("voiceFallbackMethod")]
    public HttpMethod? VoiceFallbackMethod { get; set; }
    [JsonPropertyName("renewalDate")]
    public DateTime RenewalDate { get; set;  }
    [JsonPropertyName("purchaseDate")]
    public DateTime PurchaseDate { get; set; }
    [JsonPropertyName("region")]
    public string? Region { get; set; }
    [JsonPropertyName("timezone")]
    public int TimeZone { get; set; }
    [JsonPropertyName("smsUrl")]
    public Uri? SmsUrl { get; set; }
    [JsonPropertyName("smsMethod")]
    public HttpMethod? SmsMethod { get; set; }
    [JsonPropertyName("smsFallbackUrl")]
    public Uri? SmsFallbackUrl { get; set; }
    [JsonPropertyName("smsFallbackMethod")]
    public HttpMethod? SmsFallbackMethod { get; set; }
    [JsonPropertyName("heartbeatUrl")]
    public Uri? HeartbeatUrl { get; set; }
    [JsonPropertyName("heartbeatMethod")]
    public HttpMethod? HeartbeatMethod { get; set; }
    [JsonPropertyName("hangupCallbackUrl")]
    public Uri? HangupCallbackUrl { get; set; }
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