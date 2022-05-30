using Microsoft.AspNetCore.Mvc;
using Ytel.Call;

namespace Ytel.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CallController : ControllerBase
{
    private readonly YtelService _ytelService;

    public CallController(YtelService ytelService)
    {
        _ytelService = ytelService;
    }
    
    [HttpPost]
    public async Task<ActionResult<YtelApiResponse<MakeCallOutput>>> MakeCall(
        [FromBody] MakeCallInput input)
    {
        var callInfo = await _ytelService.Call.MakeCall(input);
        return Ok(callInfo);
    }
}