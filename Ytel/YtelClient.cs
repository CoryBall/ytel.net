using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Ytel.Call;
using Ytel.Configuration;
using Ytel.Numbers;

namespace Ytel;

public class YtelClient
{
    public YtelClient(HttpClient httpClient, IOptions<YtelClientConfiguration> configuration)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.Value.ApiToken);
        Numbers = new YtelNumberClient(httpClient);
        Call = new YtelCallClient(httpClient);
    }
    
    public YtelNumberClient Numbers { get; }
    public YtelCallClient Call { get; }
}