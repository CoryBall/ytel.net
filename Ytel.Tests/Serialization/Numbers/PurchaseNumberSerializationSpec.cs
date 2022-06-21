using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Serialization.Numbers;

public class PurchaseNumberSerializationSpec
{
    [Fact]
    public void TestDeserialization()
    {
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<YtelNumber>>(_json);
        Assert.NotStrictEqual(deserialized, _object);
    }

    [Fact]
    public void TestDeserializationWithError()
    {
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<YtelNumber>>(_jsonWithError);
        Assert.NotStrictEqual(deserialized, _objectWithError);
    }
    
    [Fact]
    public void TestSerialization()
    {
        var json = JsonSerializer.Serialize(_object);
        Assert.Equal(json, _json);
    }

    [Fact]
    public void TestSerializationWithError()
    {
        var json = JsonSerializer.Serialize(_objectWithError);
        Assert.Equal(json, _jsonWithError);
    }

    private readonly YtelApiResponse<YtelNumber> _object = new()
    {
        Status = true,
        Count = 1,
        Page = 1,
        Payload = new List<YtelNumber>()
        {
            new()
            {
                AccountSid = Guid.Parse("17d55681-dca3-11ec-afed-81e3a8f1e7f7"),
                PhoneSid = Guid.Parse("158b7b30-df90-11ec-a503-7dcae0210a49"),
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
            }
        }
    };
    
    // Taken directly from docs https://api-docs.ytel.com/#bda55403-b7c1-4193-a1dc-4a791bb6da4b,
    // added extra properties found in Postman
    private readonly string _json = @"{""status"":true,""count"":1,""page"":1,""payload"":[{""accountSid"":""17d55681-dca3-11ec-afed-81e3a8f1e7f7""," +
                                    @"""phoneSid"":""158b7b30-df90-11ec-a503-7dcae0210a49"",""phoneNumber"":""\u002B14792272855"",""cnam"":""""," + 
                                    @"""renewalDate"":1656708247139,""purchaseDate"":1653857047139,""region"":""US-AR"",""timezone"":-24,""attributes"":[" + 
                                    @"""voice-enabled""],""numberType"":1}]}";

    private readonly YtelApiResponse<YtelNumber> _objectWithError = new()
    {
        Status = false,
        Count = 0,
        Page = 0,
        Error = new List<YtelApiError>()
        {
            new()
            {
                Code = "500",
                Message = "Unexpected failure",
            }
        }
    };
    private readonly string _jsonWithError =
        @"{" +
            @"""status"":false," +
            @"""count"":0," +
            @"""page"":0," +
            @"""error"":[" +
                @"{" +
                    @"""code"":""500""," +
                    @"""message"":""Unexpected failure""," +
                    @"""moreInfo"":null" +
                @"}" +
            @"]" +
        @"}";
}