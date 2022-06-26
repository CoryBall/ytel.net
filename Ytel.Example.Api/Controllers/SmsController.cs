using Microsoft.AspNetCore.Mvc;
using Ytel.Example.Api.DataTransferObjects;
using Ytel.Numbers;
using Ytel.Sms;

namespace Ytel.Example.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class SmsController : ControllerBase
    {
        private readonly YtelClient _ytelClient;

        public SmsController(YtelClient ytelClient)
        {
            _ytelClient = ytelClient;
        }

        [HttpPost]
        public async Task<ActionResult<YtelApiResponse<SendSmsOutput>>> MakeCall(
        [FromBody] SendSmsInputDto request,
        CancellationToken ct = default)
        {
            var ytelNumbers = await _ytelClient.Numbers.GetNumbersAsync(ct);
            var ytelNumber = ytelNumbers?.Payload?.FirstOrDefault(x => x.Attributes != null && x.Attributes.Contains(YtelNumberAttribute.Sms));
            if (ytelNumber == null)
            {
                return BadRequest("No Ytel number found with SMS capability");
            }

            var smsInput = new SendSmsInput(request.ToPhoneNumber, ytelNumber.PhoneNumber, request.Text);
            var ytelSmsResponse = await _ytelClient.Sms.SendSms(smsInput, ct);
            var ytelSms = ytelSmsResponse?.Payload?.First();
            if (ytelSms == null)
            {
                return BadRequest("Could not send Sms");
            }

            return Ok(ytelSms);
        }
    }
}
