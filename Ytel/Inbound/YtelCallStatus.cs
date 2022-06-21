using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Ytel.Inbound;

[JsonConverter(typeof(StringEnumConverter))]
public enum YtelCallStatus
{
    [EnumMember(Value = "in-queue")]
    InQueue,
    [EnumMember(Value = "dialing")]
    Dialing,
    [EnumMember(Value = "in-progress")]
    InProgress,
    [EnumMember(Value = "user_busy")]
    UserBusy,
    [EnumMember(Value = "no_answer")]
    NoAnswer,
    [EnumMember(Value = "insufficient_funds")]
    InsufficientFunds,
    [EnumMember(Value = "unallocated_numbers")]
    UnallocatedNumbers,
    [EnumMember(Value = "completed")]
    Completed
}