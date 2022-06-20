using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Ytel.Inbound;

[XmlRoot("Dial")]
public class Dial
{
    [XmlText]
    public string Text { get; set; } = null!;

    [XmlAttribute("action")]
    public string? Action { get; set; }
    [XmlAttribute("method")]
    public string? Method { get; set; }

    [XmlAttribute("timeout")]
    public string? TimeOut { get; set; }
    [XmlAttribute("timeLimit")]
    public string? TimeLimit { get; set; }
    [XmlAttribute("callerId")]
    public string? CallerId { get; set; }
    [XmlAttribute("hideCallerId")]
    public string? HideCallerId { get; set; }
    [XmlAttribute("dialMusic")]
    public string? DialMusic { get; set; }
    [XmlAttribute("callbackUrl")]
    public string? CallbackUrl { get; set; }
    [XmlAttribute("callbackMethod")]
    public string? CallbackMethod { get; set; }
    [XmlAttribute("confirmSound")]
    public string? ConfirmSound { get; set; }
    [XmlAttribute("heartbeatUrl")]
    public string? HeartBeatUrl { get; set; }
    [XmlAttribute("heartbeatMethod")]
    public string? HeartbeatMethod { get; set; }
    [XmlAttribute("groupConfirmKey")]
    public string? GroupConfirmKey { get; set; }
    [XmlAttribute("groupConfirmFile")]
    public string? GroupConfirmFile { get; set; }
    [XmlAttribute("onAnswerPlay")]
    public string? OnAnswerPlay { get; set; }
    [XmlAttribute("onAnswerSay")]
    public string? OnAnswerSay { get; set; }
    [XmlAttribute("CallerName")]
    public string? CallerName { get; set; }
    [XmlAttribute("PlayDTMF")]
    public string? PlayDtmf { get; set; }
    [XmlAttribute("PlayDTMFDelay")]
    public string? PlayDtmfDelay { get; set; }
    
    
    public Dial()
    {
    }

    public Dial(
        E164PhoneNumber phoneNumber,
        string? action = null,
        DialMethod? method = null,
        int? timeout = null,
        int? timeLimit = null,
        string? callerId = null,
        bool? hideCallerId = null,
        string? dialMusic = null,
        string? callbackUrl = null,
        DialMethod? callbackMethod = null,
        bool? confirmSound = null,
        string? heartBeatUrl = null,
        DialMethod? heartbeatMethod = null,
        string? groupConfirmFile = null,
        string? groupConfirmKey = null,
        string? onAnswerPlay = null,
        string? onAnswerSay = null,
        string? callerName = null,
        string? playDtmf = null,
        string? playDtmfDelay = null)
    {
        Text = phoneNumber.PhoneNumber;
        Action = action;
        Method = method?.GetType()
            .GetMember(method.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name;
        TimeOut = timeout?.ToString() ?? null;
        TimeLimit = timeLimit?.ToString() ?? null;
        CallerId = callerId;
        HideCallerId = hideCallerId.HasValue ? (hideCallerId.Value ? "TRUE" : "FALSE") : null;
        DialMusic = dialMusic;
        CallbackUrl = callbackUrl;
        CallbackMethod = callbackMethod?.GetType()
            .GetMember(callbackMethod.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name;
        ConfirmSound = confirmSound.HasValue ? (confirmSound.Value ? "TRUE" : "FALSE") : null;
        HeartBeatUrl = heartBeatUrl;
        HeartbeatMethod = heartbeatMethod?.GetType()
            .GetMember(heartbeatMethod.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<XmlEnumAttribute>()?.Name;
        GroupConfirmFile = groupConfirmFile;
        GroupConfirmKey = groupConfirmKey;
        OnAnswerPlay = onAnswerPlay;
        OnAnswerSay = onAnswerSay;
        CallerName = callerName;
        PlayDtmf = playDtmf;
        PlayDtmfDelay = playDtmfDelay;
    }

    public Dial(List<E164PhoneNumber> phoneNumbers)
    {
        Text = string.Join(",", phoneNumbers.Select(x => x.PhoneNumber));
    }
}

public enum DialMethod
{
    [XmlEnum("GET")]
    Get,
    [XmlEnum("POST")]
    Post,
}