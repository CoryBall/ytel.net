using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Sms
{
    public interface IYtelSmsClient
    {
        Task<YtelApiResponse<SendSmsOutput>?> SendSms(SendSmsInput input, CancellationToken ct = default);
    }
}
