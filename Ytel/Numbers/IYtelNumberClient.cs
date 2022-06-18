using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Numbers;

public interface IYtelNumberClient
{
    Task<YtelApiResponse<YtelNumber>?> GetNumbersAsync(CancellationToken ct = default);
    Task<YtelApiResponse<YtelNumber>?> GetNumberAsync(string phoneNumber, CancellationToken ct = default);
    Task<YtelApiResponse<GetAvailableNumbersOutput>?> GetAvailableNumbersAsync(GetAvailableNumbersInput input, CancellationToken ct = default);
    Task<YtelApiResponse<YtelNumber>?> PurchaseNumberAsync(PurchaseNumberInput input, CancellationToken ct = default);
    Task<YtelApiResponse<YtelNumber>?> ReleaseNumberAsync(ReleaseNumberInput input, CancellationToken ct = default);
}