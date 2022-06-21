using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Flurl;

namespace Ytel.Numbers;

public class YtelNumberClient : YtelBaseService, IYtelNumberClient
{
    public YtelNumberClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<YtelApiResponse<YtelNumber>?> GetNumbersAsync(CancellationToken ct = default)
    {
        const string uri = YtelNumbersEndpoints.GetNumbers;
        using var result = await _httpClient.GetAsync(uri, ct).ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<YtelNumber>>(contentStream, options: default, ct);
    }

    public async Task<YtelApiResponse<YtelNumber>?> GetNumberAsync(string phoneNumber, CancellationToken ct = default)
    {
        var uri = $"{YtelNumbersEndpoints.GetNumbers}{phoneNumber}/";
        
        using var result = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<YtelNumber>>(contentStream, options: default, ct);
    }

    public async Task<YtelApiResponse<GetAvailableNumbersOutput>?> GetAvailableNumbersAsync(GetAvailableNumbersInput input, CancellationToken ct = default)
    {
        var uri = YtelNumbersEndpoints.GetAvailableNumbers.SetQueryParams(new
        {
            areaCode = string.Join(",", input.AreaCodes).ToLower(),
            size = input.Size,
            includeFeatures = string.Join(",", input.IncludedFeatures).ToLower(),
            excludedFeatures = string.Join(",", input.ExcludedFeatures).ToLower()
        });
        
        using var result = await _httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<GetAvailableNumbersOutput>>(contentStream, options: default, ct);
    }

    public async Task<YtelApiResponse<YtelNumber>?> PurchaseNumberAsync(PurchaseNumberInput input,
        CancellationToken ct = default)
    {
        const string uri = YtelNumbersEndpoints.PurchaseNumber;
        var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        using var result = await _httpClient.PostAsync(uri, content, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<YtelNumber>>(contentStream,
            options: default, ct);
    }
    
    public async Task<YtelApiResponse<YtelNumber>?> ReleaseNumberAsync(ReleaseNumberInput input,
        CancellationToken ct = default)
    {
        const string uri = YtelNumbersEndpoints.ReleaseNumber;
        var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        using var result = await _httpClient.PostAsync(uri, content, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<YtelNumber>>(contentStream,
            options: default, ct);
    }
}