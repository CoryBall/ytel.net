
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Sms
{
    public class YtelSmsClient : YtelBaseService, IYtelSmsClient
    {
        public YtelSmsClient(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<YtelApiResponse<SendSmsOutput>?> SendSms(SendSmsInput input, CancellationToken ct = default)
        {
            const string uri = YtelSmsEndpoints.SendSms;
            var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
            using var result = await _httpClient.PostAsync(uri, content, ct)
                .ConfigureAwait(false);
            using var contentStream = await result.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<YtelApiResponse<SendSmsOutput>?>(contentStream,
            options: default, ct);
        }
    }
}
