using System;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Numbers;

public class NumberSpec
{
    [Fact]
    public void TestSerialization()
    {
        
    }

    [Fact]
    public void TestDeserialization()
    {
        
    }

    private readonly Number _object = new()
    {
        AccountSid = _guid,
        PhoneSide = _guid,
        
    };

    private readonly string _json = "";

    private static readonly Guid _guid = new();
}