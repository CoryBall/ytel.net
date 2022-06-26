using System;
using System.Text.Json.Serialization;
using Ytel.Serialization;

namespace Ytel.Sms
{
    public class SendSmsOutput
    {
        [JsonPropertyName("messageSid")]
        public Guid MessageSid { get; set; }
        [JsonPropertyName("to")]
        public string To { get; set; } = null!;
        [JsonPropertyName("from")]
        public string From { get; set; } = null!;
        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;
        [JsonPropertyName("messageCount")]
        public int MessageCount { get; set; }
        [JsonPropertyName("messageStatusMethod")]
        public string? MessageStatusMethod { get; set; }
        [JsonPropertyName("messageStatusCallback")]
        public string? MessageStatusCallback { get; set; }
        [JsonPropertyName("deliveryStatusEnabled")]
        public bool? DeliveryStatusEnabled { get; set; }
        [JsonPropertyName("mediaUrl")]
        public string? MediaUrl { get; set; }
        [JsonPropertyName("toCC")]
        public int ToCc { get; set; }
        [JsonPropertyName("toCountry")]
        public string ToCountry { get; set; } = null!;
        [JsonPropertyName("fromCC")]
        public int FromCc { get; set; }
        [JsonPropertyName("fromCountry")]
        public string FromCountry { get; set; } = null!;
        [JsonPropertyName("scheduledTm")]
        [JsonConverter(typeof(DateTimeTickJsonConverter))]
        public DateTime ScheduledTime { get; set; }
    }
}
