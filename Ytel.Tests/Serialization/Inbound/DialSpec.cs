using System.Collections.Generic;
using Xunit;
using Ytel.Inbound;
using Ytel.Serialization;

namespace Ytel.Tests.Serialization.Inbound;

public class DialSpec
{
    [Fact]
    public void TestDialSerialization()
    {
        var serializedObject = YtelXmlSerializer.Serialize(_inboundObject);
        Assert.Equal(serializedObject, _inboundXml);
    }

    [Fact]
    public void TestDialWithPhoneListSerialization()
    {
        var serializedObject = YtelXmlSerializer.Serialize(_inboundObjectWithPhoneList);
        Assert.Equal(serializedObject, _inboundXmlWithPhoneList);
    }
    
    private readonly InboundXml _inboundObject = new()
    {
        Dial = new Dial(new E164PhoneNumber("14794794794"))
    };
    
    private readonly InboundXml _inboundObjectWithPhoneList = new()
    {
        Dial = new Dial(new List<E164PhoneNumber>{new ("14794794794"), new ("19998887777")})
    };

    private readonly string _inboundXml =
        @"<Response>" + "\n  " +
        @"<Dial>+14794794794</Dial>" + "\n" +
        @"</Response>";

    private readonly string _inboundXmlWithPhoneList =
        @"<Response>" + "\n  " +
        @"<Dial>+14794794794,+19998887777</Dial>" + "\n" +
        @"</Response>";
}