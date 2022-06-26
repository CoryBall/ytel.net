using System;
using System.Buffers.Text;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ytel.Serialization;

public class DateTimeTickJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(DateTime));

        if (Utf8Parser.TryParse(reader.ValueSpan, out long value, out _))
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(value);
        }

        throw new FormatException();
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}