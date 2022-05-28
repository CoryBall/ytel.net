using System.Threading;
using System.Threading.Tasks;

namespace Ytel.Numbers;

public interface INumbersService
{
    Task<YtelApiResponse<GetAvailableNumbersOutput>?> GetAvailableNumbersAsync(GetAvailableNumbersInput input, CancellationToken ct = default);
    Task<YtelApiResponse<PurchaseNumberOutput>?> PurchaseNumberAsync(PurchaseNumberInput input, CancellationToken ct = default);
}