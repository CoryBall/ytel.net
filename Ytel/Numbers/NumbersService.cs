using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Flurl;

namespace Ytel.Numbers;

public class NumbersService : YtelBaseService, INumbersService
{
    public NumbersService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<YtelApiResponse<GetAvailableNumbersOutput>?> GetAvailableNumbersAsync(GetAvailableNumbersInput input, CancellationToken ct = default)
    {
        var uri = NumbersEndpoints.GetAvailableNumbers.SetQueryParams(new
        {
            areaCode = string.Join(",", input.AreaCodes).ToLower(),
            size = input.Size,
            includeFeatures = string.Join(",", input.IncludedFeatures).ToLower(),
            excludedFeatures = string.Join(",", input.ExcludedFeatures).ToLower()
        });
        
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<GetAvailableNumbersOutput>>(contentStream, options: default, ct);
    }

    public async Task<YtelApiResponse<PurchaseNumberOutput>?> PurchaseNumberAsync(PurchaseNumberInput input,
        CancellationToken ct = default)
    {
        const string uri = NumbersEndpoints.PurchaseNumber;
        var request = new HttpRequestMessage(HttpMethod.Post, uri);
        using var result = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<PurchaseNumberOutput>>(contentStream,
            options: default, ct);
    }
}