using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SensitiveString.Json;

public abstract class SensitiveStringJsonConverter<TSensitiveString> : JsonConverter<TSensitiveString>
    where TSensitiveString : SensitiveString
{
    public abstract override TSensitiveString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);

    public override void Write(Utf8JsonWriter writer, TSensitiveString value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Reveal());
    }
}

/// <summary>
///     Enables proper JSON conversion of the <see cref="SensitiveString" /> type.
/// </summary>
public class SensitiveStringJsonConverter : SensitiveStringJsonConverter<SensitiveString>
{
    public override SensitiveString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitive()!;
}