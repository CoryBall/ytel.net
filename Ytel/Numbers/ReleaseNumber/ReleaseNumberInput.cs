using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

public class ReleaseNumberInput
{
    [Required]
    [JsonPropertyName("phoneNumber")]
    public List<string> PhoneNumbers { get; set; } = new();
}