using Microsoft.AspNetCore.Mvc;
using Ytel.Inbound;
using Ytel.Inbound.Ssml;

namespace Ytel.Example.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class WebhooksController : YtelInboundController
{
    [HttpPost("call")]
    public YtelInboundResponse OutgoingCallXml([FromForm] MakeCallUrlRequest request)
    {
        var response = new InboundXml
        {
            Say = new Say("Thank you for using Ytel.Net. Call was placed Successfully.", SayVoice.AmericanMale2, 1, false),
        };
        return YtelResponse(response);
    }

    [HttpPost("call-status")]
    public IActionResult OutgoingCallStatusUrl([FromForm] MakeCallStatusRequest request)
    {
        return Ok();
    }

    [HttpPost("call-heartbeat")]
    public IActionResult OutgoingCallHeartbeatUrl([FromForm] MakeCallHeartbeatRequest request)
    {
        return Ok();
    }

    [HttpPost("call-inbound")]
    public IActionResult InboundCall([FromForm] InboundCallRequest request)
    {
        var response = new InboundXml
        {
            Say = new Say("Thank you for using Ytel.Net. Call was placed Successfully.", SayVoice.AmericanMale2, 1, false),
        };
        return YtelResponse(response);
    }


    [HttpPost("sms-inbound")]
    public IActionResult InboundText([FromForm] InboundSmsRequest request)
    {
        return Ok();
    }
}

public class InboundDialInput
{
    public string PhoneNumber1 { get; set; } = null!;
    public string PhoneNumber2 { get; set; } = null!;
}