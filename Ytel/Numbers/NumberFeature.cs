using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NumberFeature
{
    Voice = 0,
    Sms = 1,
    Mms = 2
}