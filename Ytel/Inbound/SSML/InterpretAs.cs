using System.Xml.Serialization;

namespace Ytel.Inbound.Ssml;

public enum InterpretAs
{
    [XmlEnum("cardinal")]
    Cardinal,
    [XmlEnum("ordinal")]
    Ordinal,
    [XmlEnum("characters")]
    Characters,
    [XmlEnum("fraction")]
    Fraction,
    [XmlEnum("expletive")]
    Expletive,
    [XmlEnum("beep")]
    Beep,
    [XmlEnum("unit")]
    Unit,
    [XmlEnum("verbatim")]
    Verbatim,
    [XmlEnum("spell-out")]
    SpellOut,
    [XmlEnum("time")]
    Time,
    [XmlEnum("date")]
    Date,
}