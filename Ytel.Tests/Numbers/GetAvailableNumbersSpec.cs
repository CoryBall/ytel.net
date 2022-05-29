using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Numbers;

public class GetAvailableNumbersSpec
{
    [Fact]
    public void TestSerialization()
    {
        var json = JsonSerializer.Serialize(_object);
        Assert.Equal(json, _json);
    }
    
    [Fact]
    public void TestDeserialization()
    {
        var deserialized = JsonSerializer.Deserialize<GetAvailableNumbersOutput>(_json);
        Assert.NotStrictEqual(deserialized, _object);
    }
    
    private readonly GetAvailableNumbersOutput _object = new()
    {
        PhoneNumber = "+12223334444",
        Region = "US-MI",
        TimeZone = -20,
        Attributes = new List<NumberAttribute>()
        {
            NumberAttribute.Voice
        },
        NumberType = 1
    };

    private readonly string _json = @"{""phoneNumber"":""\u002B12223334444"",""region"":""US-MI"",""timezone"":-20,""attributes"":[""voice-enabled""],""numberType"":1}";
}