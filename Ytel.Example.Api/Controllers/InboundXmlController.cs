using Microsoft.AspNetCore.Mvc;
using Ytel.Inbound;
using Ytel.Inbound.Ssml;

namespace Ytel.Example.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class InboundXmlController : YtelInboundController
{
    [HttpGet]
    public YtelInboundResponse ExampleXml()
    {
        var response = new InboundXml
        {
            Say = new Say("test say value", SayVoice.AmericanFemale1, 4, false)
        };

        return YtelResponse(response);
    }

    [HttpPost]
    public YtelInboundResponse GroupCall([FromForm] InboundCallRequest request)
    {
        var response = new InboundXml
        {
            Say = new Say("Thank you for using Ytel.Net. We are connecting your call now.", SayVoice.AmericanMale2, 1, false),
        };

        return YtelResponse(response);
    }
}

public class InboundDialInput
{
    public string PhoneNumber1 { get; set; } = null!;
    public string PhoneNumber2 { get; set; } = null!;
}