using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Ytel.Serialization;

public static class YtelXmlSerializer
{
    public static string Serialize<T>(T input)
    {
        var xsSubmit = new XmlSerializer(typeof(T));
        var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        using var sww = new StringWriter();
        using var writer = XmlWriter.Create(sww, new XmlWriterSettings{OmitXmlDeclaration = true, Indent = true});
        xsSubmit.Serialize(writer, input!, ns);
        return sww.ToString().Replace("&lt;", "<").Replace("&gt;", ">");
    }
}