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
    
    [HttpGet("available")]
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

    [HttpGet]
    public async Task<ActionResult<YtelApiResponse<Number>>> GetNumbers()
    {
        var numbers = await _ytelService.Numbers.GetNumbersAsync();
        return Ok(numbers);
    }

    [HttpGet("{phoneNumber}")]
    public async Task<ActionResult<YtelApiResponse<Number>>> GetNumber(string phoneNumber)
    {
        var number = await _ytelService.Numbers.GetNumberAsync(phoneNumber);
        return Ok(number);
    }

    [HttpPost("release")]
    public async Task<ActionResult<YtelApiResponse<Number>>> ReleaseNumbers([FromBody] ReleaseNumberInput input)
    {
        var numbers = await _ytelService.Numbers.ReleaseNumberAsync(input);
        return Ok(numbers);
    }
}