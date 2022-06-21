using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ytel.Inbound;

public class MakeCallHeartbeatRequest : MakeCallUrlRequest
{
    public DateTime CallInitiate { get; set; }
    public DateTime CallStartTime { get; set; }
    public YtelCallDirection? Direction { get; set; }
    public string Status { get; set; } = null!;
    public YtelCallStatus GetStatus()
    {
        var statusEnumName = typeof(YtelCallStatus)
            .GetMembers()
            .FirstOrDefault(
                x => x.GetCustomAttribute<EnumMemberAttribute>()?.Value == Status
            )?.Name;

        Enum.TryParse<YtelCallStatus>(statusEnumName, out var enumValue);
        return enumValue;
    }
}