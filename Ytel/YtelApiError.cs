using System.Text.Json.Serialization;

namespace Ytel
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class YtelApiError
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = "";
        [JsonPropertyName("message")]
        public string Message { get; set; } = "";
        [JsonPropertyName("moreInfo")]
        public string MoreInfo { get; set; } = "";
    }
}