using Xunit;
using Ytel.Inbound;
using Ytel.Serialization;

namespace Ytel.Tests.Serialization.Inbound;

public class PlaySpec
{
    [Fact]
    public void TestPlaySerialization()
    {
        var serializedObject = YtelXmlSerializer.Serialize(_inboundObject);
        Assert.Equal(serializedObject, _inboundXml);
    }
    
    private readonly InboundXml _inboundObject = new()
    {
        Play = new Play("https://mixkit.co/free-sound-effects/download/1361/?filename=mixkit-on-hold-ringtone-1361.wav", 3)
    };

    private readonly string _inboundXml =
        @"<Response>" + "\n  " +
        @"<Play loop=""3"">https://mixkit.co/free-sound-effects/download/1361/?filename=mixkit-on-hold-ringtone-1361.wav</Play>" + "\n" +
        @"</Response>";
}