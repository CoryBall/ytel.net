using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;
using Ytel.Call;

namespace Ytel.Tests.Serialization.Call;

public class MakeCallSpec
{
    [Fact]
    public void TestInputDeserialization()
    {
        var deserialized = JsonSerializer.Deserialize<MakeCallInput>(_inputJson);
        Assert.NotStrictEqual(deserialized, _inputObject);
    }

    [Fact]
    public void TestInputSerialization()
    {
        var json = JsonSerializer.Serialize(_inputObject);
        Assert.Equal(json, _inputJson);
    }

    [Fact]
    public void TestOutputDeserialization()
    {
        var deserialized = JsonSerializer.Deserialize<YtelApiResponse<MakeCallOutput>>(_outputJson);
        Assert.NotStrictEqual(deserialized, _outputObject);
    }

    [Fact]
    public void TestOutputSerialization()
    {
        var json = JsonSerializer.Serialize(_outputObject);
        Assert.Equal(json, _outputJson);
    }

    private readonly MakeCallInput _inputObject = new()
    {
        From = "+19495061234",
        To = "+19492221234",
        Url = "https://customapps.ytel.com/m360/examples/welcome/index.php",
    };

    private readonly string _inputJson =
        @"{" +
        @"""from"":""\u002B19495061234""," +
        @"""to"":""\u002B19492221234""," +
        @"""url"":""https://customapps.ytel.com/m360/examples/welcome/index.php""" +
        @"}";

    private readonly YtelApiResponse<MakeCallOutput> _outputObject = new()
    {
        Status = true,
        Count = 1,
        Page = 1,
        Payload = new List<MakeCallOutput>()
        {
            new()
            {
                CallSid = Guid.Parse("c72b0210-dfd7-11ec-ae5b-2bb5e82099be"),
                CreatedTime = new DateTime(2022, 5, 30, 5, 17, 19),
            }
        }
    };

    private readonly string _outputJson =
        @"{" +
            @"""status"":true," +
            @"""count"":1," +
            @"""page"":1," +
            @"""payload"":[" +
                @"{" +
                    @"""callSid"":""c72b0210-dfd7-11ec-ae5b-2bb5e82099be""," +
                    @"""createdTime"":""2022-05-30 05:17:19""" +
                @"}" +
            @"]" +
        @"}";
}