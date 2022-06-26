using System;

namespace Ytel.Inbound
{
    public class InboundSmsRequest
    {
        public string? Action { get; set; }
        public DateTime? DateSent { get; set; }
        public string From { get; set; } = null!;
        public string? MediaUrl { get; set; }
        public Guid? MessageSid { get; set; }
        public string Method { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime? Time { get; set; }
        public string To { get; set; } = null!;
    }
}
