using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Serialization.Numbers;

public class NumberAttributeSpec
{
    [Fact]
    public void TestSerialization()
    {
        var json = JsonSerializer.Serialize(_object);
        Assert.Equal( _json, json);
    }
    [Fact]
    public void TestDeserialization()
    {
        var deserialized = JsonSerializer.Deserialize<NumberAttribute>(_json);
        Assert.Equal(_object, deserialized);
    }

    private readonly NumberAttribute _object = NumberAttribute.Voice;
    private readonly string _json = @"""voice-enabled""";
}