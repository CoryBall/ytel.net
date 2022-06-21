using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Ytel.Inbound;

public class MakeCallStatusRequest : MakeCallUrlRequest
{
    public YtelCallDirection Direction { get; set; }
    public string Status { get; set; } = null!;
    public int? BilledDuration { get; set; }
    public DateTime? CallInitiate { get; set; }
    public DateTime? CallStartTime { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? EndTime { get; set; }
    public string? HangupBy { get; set; }

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