using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Numbers;

public class GetAvailableNumbersSpec
{
    [Fact]
    public void TestDeserialization()
    {
        var testObject = new YtelApiResponse<GetAvailableNumbersOutput>()
        {
            Status = true,
            Count = 1,
            Page = 1,
            Payload = new List<GetAvailableNumbersOutput>
            {
                new()
                {
                    PhoneNumber = "+12223334444",
                    Region = "US-MI",
                    TimeZone = -20,
                    Attributes = new List<NumberAttribute>()
                    {
                        NumberAttribute.Voice
                    },
                    NumberType = 1
                }
            }
        };
        var testJsonString =
            @"{""status"":true,""count"":1,""page"":1,""payload"":[{""phoneNumber"":""\u002B12223334444"",""region"":""US-MI"",""timezone"":-20,""attributes"":[""voice-enabled""],""numberType"":1}],""error"":null}";
        var json = JsonSerializer.Serialize(testObject);
        
        Assert.Equal(json, testJsonString);
        
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<GetAvailableNumbersOutput>>(json);
        
        Assert.NotStrictEqual(deserialized, testObject);
    }
}