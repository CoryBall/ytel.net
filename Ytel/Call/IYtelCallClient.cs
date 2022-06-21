using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Call;

public interface IYtelCallClient
{
    Task<YtelApiResponse<MakeCallOutput>?> MakeCall(MakeCallInput input, CancellationToken ct = default);
    Task<YtelApiResponse<MakeCallOutput>?> MakeGroupCall(MakeGroupCallInput input, CancellationToken ct = default);
}