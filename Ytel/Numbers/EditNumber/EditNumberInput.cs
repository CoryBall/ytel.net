using System.Text.Json.Serialization;

namespace Ytel.Numbers
{
    public class EditNumberInput
    {
        [JsonPropertyName("friendlyName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FriendlyName { get; set; }

        [JsonPropertyName("hangupCallbackUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HangupCallbackUrl { get; set; }

        [JsonPropertyName("hangupCallbackMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HangupCallbackMethod { get; set; }

        [JsonPropertyName("heartbeatUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HeartbeatUrl { get; set; }

        [JsonPropertyName("heartbeatMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? HeartbeatMethod { get; set; }

        [JsonPropertyName("voiceUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? VoiceUrl { get; set; }

        [JsonPropertyName("voiceMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? VoiceMethod { get; set; }

        [JsonPropertyName("voiceFallbackUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? VoiceFallbackUrl { get; set; }

        [JsonPropertyName("voiceFallbackMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? VoiceFallbackMethod { get; set; }

        [JsonPropertyName("smsUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SmsUrl { get; set; }

        [JsonPropertyName("smsMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SmsMethod { get; set; }

        [JsonPropertyName("smsFallbackUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SmsFallbackUrl { get; set; }

        [JsonPropertyName("smsFallbackMethod")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SmsFallbackMethod { get; set; }
    }
}
