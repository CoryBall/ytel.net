using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ytel.Serialization;

public class DateTimeRfr2822JsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(DateTime));

        var date = reader.GetString();
        if (date == null) throw new FormatException();

        var dateTimeSplit = date.Split(' ');
        if (dateTimeSplit.Length != 2) throw new FormatException();
        var dateSplit = dateTimeSplit[0].Split('-').Select(int.Parse).ToArray();
        if (dateSplit.Length != 3) throw new FormatException();
        var timeSplit = dateTimeSplit[1].Split(':').Select(int.Parse).ToArray();
        if (timeSplit.Length != 3) throw new FormatException();

        return new DateTime(dateSplit[0], dateSplit[1], dateSplit[2], timeSplit[0], timeSplit[1], timeSplit[2]);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}