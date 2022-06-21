using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ytel.Call;

public class MakeGroupCallInput : MakeCallBaseInput
{
    /// <summary>
    /// Must supply either this OR "ContactId" 
    /// </summary>
    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? To { get; set; }
    
    /// <summary>
    /// Must supply either this OR "To"
    /// </summary>
    [JsonPropertyName("contactIds")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<Guid>? ContactIds { get; set; }

    public override void Validate()
    {
        base.Validate();
        if (To == null && ContactIds == null)
        {
            throw new ArgumentException("Must supply either To OR ContactIds to make call");
        }
    }
}