using System.Collections.Generic;

namespace Ytel.Numbers
{
    public class GetAvailableNumbersInput
    {
        public List<int> AreaCodes { get; set; } = new();
        public int Size { get; set; }
        public List<NumberFeature> IncludedFeatures { get; set; } = new();
        public List<NumberFeature> ExcludedFeatures { get; set; } = new();
    }
}