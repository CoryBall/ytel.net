using System.Xml.Serialization;

namespace Ytel.Inbound;

[XmlRoot("Hangup")]
public class Hangup
{
    [XmlAttribute("schedule")]
    public string? Schedule { get; set; }

    public Hangup()
    {
    }

    public Hangup(int? schedule = null)
    {
        Schedule = schedule?.ToString() ?? null;
    }
}