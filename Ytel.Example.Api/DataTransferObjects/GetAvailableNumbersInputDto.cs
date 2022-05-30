using System.ComponentModel.DataAnnotations;
using Ytel.Numbers;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Ytel.Example.Api.DataTransferObjects;

public class GetAvailableNumbersInputDto
{
    [Required] public List<int> AreaCodes { get; set; } = new();
    [Required]
    public int Size { get; set; }

    public List<NumberFeature> IncludedFeatures { get; set; } = new();
    public List<NumberFeature> ExcludedFeatures { get; set; } = new();

    public GetAvailableNumbersInput ToInput()
    {
        Console.WriteLine(this);
        return new GetAvailableNumbersInput()
        {
            AreaCodes = AreaCodes,
            Size = Size,
            IncludedFeatures = IncludedFeatures,
            ExcludedFeatures = ExcludedFeatures
        };
    }
}