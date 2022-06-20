using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Ytel.Serialization;

namespace Ytel.Inbound.Ssml;

[Serializable]
[XmlRoot("say-as")]
public class SayAs
{
    [XmlAttribute("interpret-as")]
    public string InterpretAs { get; set; } = null!;
    [XmlAttribute("format")]
    public string? Format { get; set; }
    [XmlAttribute("detail")]
    public string? Detail { get; set; }

    [XmlText]
    public string Text { get; set; } = null!;

    public SayAs(string text, InterpretAs interpretAs)
    {
        Text = text;
        InterpretAs = interpretAs.GetType()
            .GetMember(interpretAs.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name ?? "";
    }
    public SayAs(string text, InterpretAs interpretAs, string? format, string? detail)
    {
        Text = text;
        InterpretAs = interpretAs.GetType()
            .GetMember(interpretAs.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name ?? "";
        Format = format;
        Detail = detail;
    }

    public SayAs()
    {
    }

    public override string ToString()
    {
        return YtelXmlSerializer.Serialize(this);
    }
}