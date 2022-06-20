namespace Ytel.Example.Api.DataTransferObjects;

public class MakeCallInputDto
{
    public string ToNumber { get; set; } = null!;
    public string ToNumber2 { get; set; } = null!;
    public string InboundUrl { get; set; } = null!;
}