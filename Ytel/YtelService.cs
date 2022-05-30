using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Ytel.Call;
using Ytel.Configuration;
using Ytel.Numbers;

namespace Ytel;

public class YtelService
{
    public YtelService(HttpClient httpClient, IOptions<YtelConfiguration> configuration)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.Value.ApiToken);
        Numbers = new NumbersService(httpClient);
        Call = new CallService(httpClient);
    }
    
    public NumbersService Numbers { get; }
    public CallService Call { get; }
}