using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Call;

public class CallService : YtelBaseService, ICallService
{
    public CallService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<YtelApiResponse<MakeCallOutput>?> MakeCall(MakeCallInput input, CancellationToken ct = default)
    {
        const string uri = CallEndpoints.MakeCall;
        var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        using var result = await _httpClient.PostAsync(uri, content, ct)
            .ConfigureAwait(false);
        using var contentStream = await result.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<YtelApiResponse<MakeCallOutput>>(contentStream,
            options: default, ct);
    }
}