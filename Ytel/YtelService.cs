using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Options;
using Ytel.Configuration;
using Ytel.Numbers;

namespace Ytel;

public class YtelService
{
    public YtelService(HttpClient httpClient, IOptions<YtelConfiguration> configuration)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration.Value.ApiToken);
        Numbers = new NumbersService(httpClient);
    }
    
    public NumbersService Numbers { get; }
}