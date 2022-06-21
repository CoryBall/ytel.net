using System;
using System.Text.Json.Serialization;

namespace Ytel.Call;

public class MakeCallInput : MakeCallBaseInput
{
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

    public MakeCallInput()
    {
    }
    public MakeCallInput(string to, string from, string inboundXmlUrl)
    {
        To = new E164PhoneNumber(to).PhoneNumber;
        From = new E164PhoneNumber(from).PhoneNumber;
        Url = inboundXmlUrl;
    }

    

    public override void Validate()
    {
        base.Validate();
        if (string.IsNullOrWhiteSpace(To) && ContactId == null)
        {
            throw new ArgumentException("Must supply either To OR ContactId to make call");
        }
    }
}