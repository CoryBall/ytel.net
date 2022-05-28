using Microsoft.AspNetCore.Mvc;
using Ytel.Example.Api.DataTransferObjects;
using Ytel.Numbers;

namespace Ytel.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PhoneNumberController : ControllerBase
{
    private readonly YtelService _ytelService;

    public PhoneNumberController(YtelService ytelService)
    {
        _ytelService = ytelService;
    }
    
    [HttpGet("/available")]
    public async Task<ActionResult<YtelApiResponse<GetAvailableNumbersOutput>>> GetAvailablePhoneNumbers([FromQuery] GetAvailableNumbersInputDto input)
    {
        var phoneNumbers = await _ytelService.Numbers.GetAvailableNumbersAsync(input.ToInput());
        return Ok(phoneNumbers);
    }
}