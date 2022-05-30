using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Call;

public interface ICallService
{
    Task<YtelApiResponse<MakeCallOutput>?> MakeCall(MakeCallInput input, CancellationToken ct = default);
}