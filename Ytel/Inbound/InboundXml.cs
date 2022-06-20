using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Ytel.Serialization;

namespace Ytel.Inbound;

[Serializable]
[XmlRoot("Response")]
public class InboundXml
{
    [XmlElement("Say")]
    public Say? Say { get; set; }

    [XmlElement("Play")]
    public Play? Play { get; set; }
    
    [XmlElement("Dial")]
    public Dial? Dial { get; set; }
    
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
    
    #endregion

    public InboundXml()
    {
    }

    public override string ToString()
    {
        return YtelXmlSerializer.Serialize(this);
    }
}

