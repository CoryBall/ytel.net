using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Serialization.Numbers;

public class GetNumbersSpec
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
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<YtelNumber>>(_json);
        Assert.NotStrictEqual(_object, deserialized);
    }

    private readonly YtelApiResponse<YtelNumber> _object = new()
    {
        Status = true,
        Count = 2,
        Page = 1,
        NextKey = "KzE0NzkyMjcyODU2",
        Payload = new List<YtelNumber>()
        {
            new()
            {
                AccountSid = Guid.Parse("173c6f7f-c911-f823-fb2d-a13e4780c300"),
                PhoneSid = Guid.Parse("25431e50-6866-11ea-9ea9-d1464f98b813"),
                PhoneNumber = "+14792272855",
                Cnam = "",
                RenewalDate = new DateTime(1656708247139),
                PurchaseDate = new DateTime(1653857047139),
                Region = "US-AR",
                TimeZone = -24,
                Attributes = new List<YtelNumberAttribute>()
                {
                    YtelNumberAttribute.Voice
                },
                NumberType = 1
            },
            new()
            {
                AccountSid = Guid.Parse("173c6f7f-c911-f823-fb2d-a13e4780c300"),
                PhoneSid = Guid.Parse("8567a510-6886-11ea-9b6f-e6478104197e"),
                PhoneNumber = "+14792272856",
                Cnam = "",
                RenewalDate = new DateTime(1656647961448),
                PurchaseDate = new DateTime(1653883161448),
                Region = "US-AR",
                TimeZone = -24,
                Attributes = new List<YtelNumberAttribute>()
                {
                    YtelNumberAttribute.Voice
                },
                NumberType = 1
            }
        }
    };
    
    // Taken from Postman response body
    private readonly string _json =
        @"{" +
            @"""status"":true," +
            @"""count"":2," +
            @"""page"":1," +
            @"""nextKey"":""KzE0NzkyMjcyODU2""," +
            @"""payload"":[" +
                @"{" +
                    @"""accountSid"":""173c6f7f-c911-f823-fb2d-a13e4780c300""," +
                    @"""phoneSid"":""25431e50-6866-11ea-9ea9-d1464f98b813""," +
                    @"""phoneNumber"":""\u002B14792272855""," +
                    @"""cnam"":""""," +
                    @"""renewalDate"":1656708247139," +
                    @"""purchaseDate"":1653857047139," +
                    @"""region"":""US-AR""," +
                    @"""timezone"":-24," +    
                    @"""attributes"":[" +
                        @"""voice-enabled""" +
                    @"]," +
                    @"""numberType"":1" +
                @"}," +
                @"{" +
                    @"""accountSid"":""173c6f7f-c911-f823-fb2d-a13e4780c300""," +
                    @"""phoneSid"":""8567a510-6886-11ea-9b6f-e6478104197e""," +
                    @"""phoneNumber"":""\u002B14792272856""," +
                    @"""cnam"":""""," +
                    @"""renewalDate"":1656647961448," +
                    @"""purchaseDate"":1653883161448," +
                    @"""region"":""US-AR""," +
                    @"""timezone"":-24," +
                    @"""attributes"":[" +
                        @"""voice-enabled""" +
                    @"]," +
                    @"""numberType"":1" +
                @"}" +
            @"]" +
        @"}";
}