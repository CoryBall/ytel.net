using System.Collections.Generic;

namespace Ytel;

public abstract class RequestInputBase
{
    public Dictionary<string, string> ToUrlQuery()
    {
        var dict = new Dictionary<string, string>();
        var properties = this.GetType().GetProperties();
        foreach (var prop in properties)
        {
            dict.Add(prop.Name.ToLower(), prop.GetValue(this).ToString().ToLower());
        }

        return dict;
    } 
}