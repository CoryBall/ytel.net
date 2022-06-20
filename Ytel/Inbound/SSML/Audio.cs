using System.Xml.Serialization;
using Ytel.Serialization;

namespace Ytel.Inbound.Ssml;


[XmlRoot("audio")]
public class Audio
{
    [XmlAttribute("src")]
    public string Source { get; set; } = null!;

    [XmlElement("desc")]
    public string Description { get; set; } = null!;

    [XmlAttribute("clipBegin")]
    public string? ClipBegin { get; set; }
    [XmlAttribute("clipEnd")]
    public string? ClipEnd { get; set; }
    [XmlAttribute("speed")]
    public string? Speed { get; set; }
    [XmlAttribute("repeatCount")]
    public string? RepeatCount { get; set; }
    [XmlAttribute("repeatDur")]
    public string? RepeatDuration { get; set; }
    [XmlAttribute("soundLevel")]
    public string? SoundLevel { get; set; }


    public Audio()
    {
    }

    public Audio(string source, string description)
    {
        Source = source;
        Description = description;
    }

    public Audio(
        string source,
        string description,
        int? clipBegin = null,
        int? clipEnd = null,
        string? speed = null,
        int? repeatCount = null,
        int? repeatDuration = null,
        string? soundLevel = null)
    {
        Source = source;
        Description = description;
        ClipBegin = clipBegin?.ToString() ?? null;
        ClipEnd = clipEnd?.ToString() ?? null;
        Speed = speed;
        RepeatCount = repeatCount?.ToString() ?? null;
        RepeatDuration = repeatDuration?.ToString() ?? null;
        SoundLevel = soundLevel;
    }
    
    public override string ToString()
    {
        return YtelXmlSerializer.Serialize(this);
    }
}