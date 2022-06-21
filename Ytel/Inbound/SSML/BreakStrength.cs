using System.Xml.Serialization;

namespace Ytel.Inbound.Ssml;

public enum BreakStrength
{
    [XmlEnum("none")]
    None,
    [XmlEnum("x-weak")]
    ExtraWeak,
    [XmlEnum("weak")]
    Weak,
    [XmlEnum("medium")]
    Medium,
    [XmlEnum("strong")]
    Strong,
    [XmlEnum("x-strong")]
    ExtraStrong
}