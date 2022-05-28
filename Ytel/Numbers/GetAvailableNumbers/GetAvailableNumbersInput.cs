using System.Collections.Generic;

namespace Ytel.Numbers
{
    public class GetAvailableNumbersInput : RequestInputBase
    {
        public List<int> AreaCodes { get; set; } = new List<int>();
        public int Size { get; set; }
        public List<NumberFeature> IncludedFeatures { get; set; } = new List<NumberFeature>();
        public List<NumberFeature> ExcludedFeatures { get; set; } = new List<NumberFeature>();
    }
}