using Microsoft.AspNetCore.Mvc;
using Ytel.Call;

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
        [FromBody] MakeCallInput input)
    {
        var callInfo = await _ytelClient.Call.MakeCall(input);
        return Ok(callInfo);
    }
}