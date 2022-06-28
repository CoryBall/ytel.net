using System.Text.Json;
using Xunit;
using Ytel.Numbers;

namespace Ytel.Tests.Serialization.Numbers
{
    public class EditNumberSpec
    {
        [Fact]
        public void TestInputSerialization()
        {
            var json = JsonSerializer.Serialize(_inputObject);
            Assert.Equal(json, _inputJson);
        }


        private readonly EditNumberInput _inputObject = new()
        {
            FriendlyName = "Test Number",
            VoiceUrl = "https://www.example.com/voice",
            SmsUrl = "https://www.example.com/sms"
        };

        private readonly string _inputJson =
            @"{" +
            @"""friendlyName"":""Test Number""," +
            @"""voiceUrl"":""https://www.example.com/voice""," +
            @"""smsUrl"":""https://www.example.com/sms""" +
            @"}";
    }
}
