
using System;
using System.Text.Json.Serialization;

namespace Ytel.Sms
{
    public class SendSmsInput
    {
        /// <summary>
        /// Must supply this OR ContactId
        /// </summary>
        [JsonPropertyName("to")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? To { get; set; }

        /// <summary>
        /// Must supply this OR To
        /// </summary>
        [JsonPropertyName("contactId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? ContactId { get; set; }

        /// <summary>
        /// Must supply this OR NumberSetId
        /// </summary>
        [JsonPropertyName("from")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? From { get; set; }

        /// <summary>
        /// Must supply this OR From
        /// </summary>
        [JsonPropertyName("numberSetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? NumberSetId { get; set; }

        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Text { get; set; }

        [JsonPropertyName("smsTemplateId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? SmsTemplateId { get; set; }

        [JsonPropertyName("mediaUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MediaUrl { get; set; }

        [JsonPropertyName("deliveryStatusEnabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DeliveryStatusEnabled { get; set; }

        [JsonPropertyName("messageStatusCallback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MessageStatusCallback { get; set; }

        public SendSmsInput()
        {
        }

        public SendSmsInput(string to, string from, string text)
        {
            To = to;
            From = from;
            Text = text;
        }

        public SendSmsInput(Guid contactId, Guid numberSetId, string text)
        {
            ContactId = contactId;
            NumberSetId = numberSetId;
            Text = text;
        }
    }
}
