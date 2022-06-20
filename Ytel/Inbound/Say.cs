using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Ytel.Inbound;

[Serializable]
[XmlRoot("Say")]
public class Say
{
    [XmlAttribute("voice")]
    public string? Voice { get; set; }

    [XmlAttribute("loop")]
    public int Loop { get; set;  } = 1;
    [XmlAttribute("type")]
    public string? Type { get; set;  }

    [XmlText] 
    public string Text { get; set;  } = null!;

    public Say()
    {
    }
    
    public Say(string text)
    {
        Text = text;
    }

    public Say(string text, SayVoice voice, int loop, bool isSsml)
    {
        Text = text;
        Voice = voice.GetType()
            .GetMember(voice.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name;
        Loop = loop;
        Type = isSsml ? "ssml" : null;
    }
}