using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ytel.Numbers;

public class PurchaseNumberInput
{
    [JsonPropertyName("numberSetId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? NumberSetId { get; set; }

    [Required]
    [JsonPropertyName("phoneNumber")]
    public List<string> PhoneNumbers { get; set; } = new();
}