using Microsoft.AspNetCore.Mvc;
using Ytel.Call;
using Ytel.Example.Api.DataTransferObjects;

namespace Ytel.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CallController : ControllerBase
{
    private readonly YtelClient _ytelClient;

    public CallController(YtelClient ytelClient)
    {
        _ytelClient = ytelClient;
    }
    
    [HttpPost]
    public async Task<ActionResult<YtelApiResponse<MakeCallOutput>>> MakeCall(
        [FromBody] MakeCallInputDto input,
        CancellationToken ct = default)
    {
        var ytelNumbers = await _ytelClient.Numbers.GetNumbersAsync(ct);
        var ytelNumber = ytelNumbers?.Payload?.First();
        if (ytelNumber == null)
        {
            return BadRequest("No Ytel number found");
        }

        var makeCallInput = new MakeCallInput(input.ToNumber, ytelNumber.PhoneNumber, input.InboundUrl);
        
        var callInfo = await _ytelClient.Call.MakeCall(makeCallInput, ct);
        return Ok(callInfo);
    }
    
    [HttpPost("/group")]
    public async Task<ActionResult<YtelApiResponse<MakeCallOutput>>> MakeGroupCall(
        [FromBody] MakeCallInputDto input,
        CancellationToken ct = default)
    {
        var ytelNumber = (await _ytelClient.Numbers.GetNumbersAsync(ct))?.Payload?.First();
        if (ytelNumber == null)
        {
            return BadRequest("No Ytel number found");
        }

        var makeCallInput = new MakeGroupCallInput
        {
            To = new List<string>{input.ToNumber, input.ToNumber2},
            From = ytelNumber.PhoneNumber,
            Url = input.InboundUrl
        };
        var callInfo = await _ytelClient.Call.MakeGroupCall(makeCallInput, ct);
        return Ok(callInfo);
    }
}