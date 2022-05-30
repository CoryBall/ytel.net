using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Serialization.Numbers;

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
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<GetAvailableNumbersOutput>>(_json);
        Assert.NotStrictEqual(deserialized, _object);
    }
    
    private readonly YtelApiResponse<GetAvailableNumbersOutput> _object = new()
    {
        Status = true,
        Count = 3,
        Page = 1,
        Payload = new List<GetAvailableNumbersOutput>()
        {
            new()
            {
                PhoneNumber = "+17142421234",
                Region = "US-CA",
                TimeZone = -32,
                Attributes = new List<NumberAttribute>()
                {
                    NumberAttribute.Voice,
                    NumberAttribute.Sms
                },
                NumberType = 1
            },
            new()
            {
                PhoneNumber = "+17144061234",
                Region = "US-CA",
                TimeZone = -32,
                Attributes = new List<NumberAttribute>()
                {
                    NumberAttribute.Mms,
                    NumberAttribute.Voice,
                    NumberAttribute.Sms
                },
                NumberType = 1
            },
            new()
            {
                PhoneNumber = "+17142421234",
                Region = "US-CA",
                TimeZone = -32,
                Attributes = new List<NumberAttribute>()
                {
                    NumberAttribute.Voice,
                    NumberAttribute.Sms
                },
                NumberType = 1
            }
        }
    };

    // Taken directly from docs https://api-docs.ytel.com/#57bd6df2-3f77-4586-8536-085e495a58fc
    private readonly string _json = @"{""status"":true,""count"":3,""page"":1,""payload"":[{""phoneNumber"":""\u002B17142421234"",""region"":""US-CA""," +
                                    @"""timezone"":-32,""attributes"":[""voice-enabled"",""sms-enabled""],""numberType"":1}," +
                                    @"{""phoneNumber"":""\u002B17144061234"",""region"":""US-CA"",""timezone"":-32,""attributes"":[""mms-enabled""," +
                                    @"""voice-enabled"",""sms-enabled""],""numberType"":1},{""phoneNumber"":""\u002B17142421234"",""region"":""US-CA""," +
                                    @"""timezone"":-32,""attributes"":[""voice-enabled"",""sms-enabled""],""numberType"":1}]}";
}