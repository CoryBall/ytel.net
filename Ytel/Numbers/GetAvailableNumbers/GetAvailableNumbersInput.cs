using System.Collections.Generic;

namespace Ytel.Numbers
{
    public class GetAvailableNumbersInput
    {
        public List<int> AreaCodes { get; set; } = new();
        public int Size { get; set; }
        public List<YtelNumberFeature> IncludedFeatures { get; set; } = new();
        public List<YtelNumberFeature> ExcludedFeatures { get; set; } = new();
    }
}