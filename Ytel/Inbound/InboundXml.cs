using System;
using System.Xml;
using System.Xml.Serialization;
using Ytel.Serialization;

namespace Ytel.Inbound;

[Serializable]
[XmlRoot("Response")]
public class InboundXml
{
    [XmlElement("Say", Order = 0)]
    public Say? Say { get; set; }

    [XmlElement("Play", Order = 1)]
    public Play? Play { get; set; }
    
    [XmlElement("Dial", Order = 2)]
    public Dial? Dial { get; set; }
    
    [XmlElement("Hangup", Order = int.MaxValue)]
    public Hangup? Hangup { get; set; }
    
    #region Serialization
    
    public bool ShouldSerializeSay()
    {
        return Say != null;
    }
    public bool ShouldSerializePlay()
    {
        return Play != null;
    }

    public bool ShouldSerializeDial()
    {
        return Dial != null;
    }

    public bool ShouldSerializeHangup()
    {
        return Hangup != null;
    }
    
    #endregion

    public InboundXml()
    {
    }

    public override string ToString()
    {
        return YtelXmlSerializer.Serialize(this);
    }
}

