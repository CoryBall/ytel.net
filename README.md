# Ytel.NET
### A C# SDK for [Ytel](https://www.ytel.com/) phone services
### Currently includes the following features:
 - Retrieving available phone numbers
 - Purchasing a phone number

### Getting Started:

1. Register a long-lived bearer token and supply it to the SDK in startup
    > From your [dashboard](https://app.ytel.com/#/dashboard), navigate to Settings -> API Tokens -> Create Token 
    ```csharp
    builder.Services.AddYtel(options =>
    {
        options.ApiToken = ytelConfig.ApiToken;
    });
    ```

2. Inject it and use it!
    ```csharp
    public class PhoneNumberController : ControllerBase
    {
        private readonly YtelService _ytelService;
    
        public PhoneNumberController(YtelService ytelService)
        {
            _ytelService = ytelService;
        }
        
        [HttpGet("/available")]
        public async Task<ActionResult<YtelApiResponse<GetAvailableNumbersOutput>>> GetAvailablePhoneNumbers(
            [FromQuery] GetAvailableNumbersInput input)
        {
            var phoneNumbers = await _ytelService.Numbers.GetAvailableNumbersAsync(input);
            return Ok(phoneNumbers);
        }
    }
    ```

### Development:
To run the solution with the included Ytel.Example.Api project,
register your Ytel API token in [dotnet secret manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=linux)
with the name `ApiToken`