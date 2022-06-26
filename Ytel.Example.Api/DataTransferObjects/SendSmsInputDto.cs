namespace Ytel.Example.Api.DataTransferObjects
{
    public class SendSmsInputDto
    {
        public string ToPhoneNumber { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
