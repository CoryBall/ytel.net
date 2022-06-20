using System.Text.Json.Serialization;

namespace Ytel.Call;

public enum YtelCallStatus
{
    [JsonPropertyName("in-queue")]
    InQueue,
    [JsonPropertyName("dialing")]
    Dialing,
    [JsonPropertyName("in-progress")]
    InProgress,
    [JsonPropertyName("user_busy")]
    UserBusy,
    [JsonPropertyName("no_answer")]
    NoAnswer,
    [JsonPropertyName("insufficient_funds")]
    InsufficientFunds,
    [JsonPropertyName("unallocated_numbers")]
    UnallocatedNumbers,
    [JsonPropertyName("completed")]
    Completed
}