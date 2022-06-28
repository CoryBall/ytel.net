using Microsoft.AspNetCore.Mvc;
using Ytel.Example.Api.DataTransferObjects;
using Ytel.Numbers;

namespace Ytel.Example.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class NumberController : ControllerBase
{
    private readonly YtelClient _ytelClient;

    public NumberController(YtelClient ytelClient)
    {
        _ytelClient = ytelClient;
    }
    
    [HttpGet("available")]
    public async Task<ActionResult<YtelApiResponse<GetAvailableNumbersOutput>>> GetAvailableNumbers(
        [FromQuery] GetAvailableNumbersInputDto input)
    {
        var phoneNumbers = await _ytelClient.Numbers.GetAvailableNumbersAsync(input.ToInput());
        return Ok(phoneNumbers);
    }

    [HttpPost("purchase")]
    public async Task<ActionResult<YtelApiResponse<YtelNumber>>> PurchaseNumbers(
        [FromBody] PurchaseNumberInput input)
    {
        var numbers = await _ytelClient.Numbers.PurchaseNumberAsync(input);
        return Ok(numbers);
    }

    [HttpGet]
    public async Task<ActionResult<YtelApiResponse<YtelNumber>>> GetNumbers()
    {
        var numbers = await _ytelClient.Numbers.GetNumbersAsync();
        return Ok(numbers);
    }

    [HttpGet("{phoneNumber}")]
    public async Task<ActionResult<YtelApiResponse<YtelNumber>>> GetNumber(string phoneNumber)
    {
        var number = await _ytelClient.Numbers.GetNumberAsync(phoneNumber);
        return Ok(number);
    }

    [HttpPost("release")]
    public async Task<ActionResult<YtelApiResponse<YtelNumber>>> ReleaseNumbers([FromBody] ReleaseNumberInput input)
    {
        var numbers = await _ytelClient.Numbers.ReleaseNumberAsync(input);
        return Ok(numbers);
    }

    [HttpPut("{phoneNumber}")]
    public async Task<ActionResult<YtelApiResponse<YtelNumber>>> EditNumber(string phoneNumber, [FromBody] EditNumberInput input, CancellationToken ct = default)
    {
        if (!string.IsNullOrWhiteSpace(input.HeartbeatUrl) && string.IsNullOrWhiteSpace(input.HeartbeatMethod))
        {
            return BadRequest("Must include heartbeatMethod");
        }
        if (!string.IsNullOrWhiteSpace(input.HangupCallbackUrl) && string.IsNullOrWhiteSpace(input.HangupCallbackMethod))
        {
            return BadRequest("Must include hangupCallbackMethod");
        }
        if (!string.IsNullOrWhiteSpace(input.VoiceUrl) && string.IsNullOrWhiteSpace(input.VoiceMethod))
        {
            return BadRequest("Must include voiceMethod");
        }
        if (!string.IsNullOrWhiteSpace(input.VoiceFallbackUrl) && string.IsNullOrWhiteSpace(input.VoiceFallbackMethod))
        {
            return BadRequest("Must include voiceFallbackMethod");
        }
        if (!string.IsNullOrWhiteSpace(input.SmsUrl) && string.IsNullOrWhiteSpace(input.SmsMethod))
        {
            return BadRequest("Must include smsMethod");
        }
        if (!string.IsNullOrWhiteSpace(input.SmsFallbackUrl) && string.IsNullOrWhiteSpace(input.SmsFallbackMethod))
        {
            return BadRequest("Must include smsFallbackMethod");
        }

        var updatedNumber = await _ytelClient.Numbers.EditNumberAsync(phoneNumber, input, ct);
        return Ok(updatedNumber);
    }
}