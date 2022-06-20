using System.Xml.Serialization;

namespace Ytel.Inbound;

[XmlRoot("Play")]
public class Play
{
    [XmlText]
    public string Text { get; set; } = null!;

    [XmlIgnore]
    public int? Loop { get; set; } = 1;

    [XmlAttribute("loop")]
    public string? LoopAsText
    {
        get => Loop != null ? Loop.ToString() : null;
        set => Loop = !string.IsNullOrWhiteSpace(value) ? int.Parse(value) : default(int?);
    }
    
    public Play()
    {
    }

    public Play(string text)
    {
        Text = text;
    }

    public Play(string text, int? loop = null)
    {
        Text = text;
        Loop = loop ?? 1;
    }
}