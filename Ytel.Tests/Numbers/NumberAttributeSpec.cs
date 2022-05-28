using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Numbers;

public class NumberAttributeSpec
{
    [Fact]
    public void TestDeserialization()
    {
        var json = JsonSerializer.Serialize(NumberAttribute.Voice);
        
        Assert.Equal( "\"voice-enabled\"", json);

        var deserialized = JsonSerializer.Deserialize<NumberAttribute>(json);
        
        Assert.Equal(NumberAttribute.Voice, deserialized);
    }
}