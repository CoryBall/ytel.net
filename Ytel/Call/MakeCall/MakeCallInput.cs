using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ytel.Call;

public class MakeCallInput
{
    /// <summary>
    /// Must supply either this OR "NumberSetId"
    /// </summary>
    [JsonPropertyName("from")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? From { get; set; }
    
    /// <summary>
    /// Must supply either this OR "From"
    /// </summary>
    [JsonPropertyName("numberSetId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? NumberSetId { get; set; }

    /// <summary>
    /// Must supply either this OR "ContactId" 
    /// </summary>
    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? To { get; set; }
    
    /// <summary>
    /// Must supply either this OR "To"
    /// </summary>
    [JsonPropertyName("contactId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Guid? ContactId { get; set; }
    
    [Required]
    [JsonPropertyName("url")]
    public string? Url { get; set; }
    
    [JsonPropertyName("statusCallbackUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StatusCallbackUrl { get; set; }
    
    [JsonPropertyName("fallbackUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FallbackUrl { get; set; }
    
    [JsonPropertyName("heartbeatCallbackUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HeartbeatCallbackUrl { get; set; }
    
    [JsonPropertyName("recordCallbackUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RecordCallbackUrl { get; set; }
    
    [JsonPropertyName("ifMachine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IfMachine? IfMachine { get; set; }

    [JsonPropertyName("ifMachineCallbackUrl")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? IfMachineCallbackUrl { get; set; }
    
    [JsonPropertyName("timeout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Timeout { get; set; }
    
    [JsonPropertyName("playDtmf")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Dialtone>? PlayDtmf { get; set; }

    [JsonPropertyName("hideCallerId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? HideCallerId { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(From) && NumberSetId == null)
        {
            throw new ArgumentException("Must supply either From OR NumberSetId to make call");
        }

        if (string.IsNullOrWhiteSpace(To) && ContactId == null)
        {
            throw new ArgumentException("Must supply either To OR ContactId to make call");
        }
    }
}