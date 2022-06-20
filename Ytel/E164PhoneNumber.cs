using PhoneNumbers;

namespace Ytel;
using PhoneNumberUtil = PhoneNumbers.PhoneNumberUtil;

public class E164PhoneNumber
{
    public string PhoneNumber { get; }

    public E164PhoneNumber(string phoneNumber)
    {
        var util = PhoneNumberUtil.GetInstance();
        var parsedNumber = util.Parse(phoneNumber, "US");
        PhoneNumber = util.Format(parsedNumber, PhoneNumberFormat.E164);
    }
}