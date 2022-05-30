using Microsoft.AspNetCore.Mvc;
using Ytel.Example.Api.DataTransferObjects;
using Ytel.Numbers;

namespace Ytel.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NumberController : ControllerBase
{
    private readonly YtelService _ytelService;

    public NumberController(YtelService ytelService)
    {
        _ytelService = ytelService;
    }
    
    [HttpGet("/available")]
    public async Task<ActionResult<YtelApiResponse<GetAvailableNumbersOutput>>> GetAvailableNumbers(
        [FromQuery] GetAvailableNumbersInputDto input)
    {
        var phoneNumbers = await _ytelService.Numbers.GetAvailableNumbersAsync(input.ToInput());
        return Ok(phoneNumbers);
    }

    [HttpPost("purchase")]
    public async Task<ActionResult<YtelApiResponse<Number>>> PurchaseNumbers(
        [FromBody] PurchaseNumberInput input)
    {
        var numbers = await _ytelService.Numbers.PurchaseNumberAsync(input);
        return Ok(numbers);
    }
}