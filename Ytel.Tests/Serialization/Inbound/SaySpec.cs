using Xunit;
using Ytel.Inbound;
using Ytel.Inbound.Ssml;
using Ytel.Serialization;

namespace Ytel.Tests.Serialization.Inbound;

public class SaySpec
{
    [Fact]
    public void TestSaySerialization()
    {
        var serializedObject = YtelXmlSerializer.Serialize(_inboundObjectWithoutSsml);
        Assert.Equal(serializedObject, _inboundXmlWithoutSsml);
    }

    [Fact]
    public void TestSayWithSsmlSerialization()
    {
        var serializedObject = YtelXmlSerializer.Serialize(_inboundObjectWithSsml);
        Assert.Equal(serializedObject, _inboundXmlWithSsml);
    }
    
    private readonly InboundXml _inboundObjectWithoutSsml = new()
    {
        Say = new Say("Test", SayVoice.AmericanFemale1, 2, false)
    };

    private readonly string _inboundXmlWithoutSsml =
        @"<Response>" + "\n  " +
        @"<Say voice=""en-us-standard-female-1"" loop=""2"">Test</Say>" + "\n" +
        @"</Response>";

    private readonly InboundXml _inboundObjectWithSsml = new()
    {
        Say = new Say(
            $"Hello {new Break(time: "200ms")}" +
            $"{new SayAs("1", InterpretAs.Ordinal)} message received" +
            $"{new Audio("https://mixkit.co/free-sound-effects/download/1361/?filename=mixkit-on-hold-ringtone-1361.wav", "On hold", soundLevel: "+10dB")}",
            SayVoice.AustralianFemale1,
            4, 
            true)
    };

    private readonly string _inboundXmlWithSsml =
        @"<Response>" + "\n  " +
        @"<Say voice=""en-au-standard-female-1"" loop=""4"" type=""ssml"">" +
        @"Hello <break time=""200ms"" />" +
        @"<say-as interpret-as=""ordinal"">1</say-as> message received" +
        @"<audio src=""https://mixkit.co/free-sound-effects/download/1361/?filename=mixkit-on-hold-ringtone-1361.wav"" soundLevel=""+10dB"">" + "\n  " +
        @"<desc>On hold</desc>" + "\n" +
        @"</audio>" +
        @"</Say>" + "\n" +
        @"</Response>";
}