using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Ytel.Serialization;

namespace Ytel.Inbound.Ssml;

[XmlRoot("break")]
public class Break
{
    [XmlAttribute(AttributeName = "time")]
    public string? Time { get; set; }
    [XmlAttribute(AttributeName = "strength")]
    public string? Strength { get; set; }

    public Break(string? time = null, BreakStrength? strength = null)
    {
        Time = time;
        Strength = strength?.GetType()
            .GetMember(strength.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name;
    }

    public Break()
    {
    }

    public override string ToString()
    {
        return YtelXmlSerializer.Serialize(this);
    }
}