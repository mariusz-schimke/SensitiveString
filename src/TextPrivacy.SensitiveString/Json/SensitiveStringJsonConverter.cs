using System.Text.Json;
using System.Text.Json.Serialization;

namespace TextPrivacy.SensitiveString.Json;

/// <summary>
///     Enables support for descendants of the <see cref="SensitiveString" /> type. The original value wrapped by them is revealed on
///     object serialization (the original value appears in the output JSON string).
/// </summary>
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
///     Enables support for the <see cref="SensitiveString" /> type. The original value wrapped by it is revealed on object
///     serialization (the original value appears in the output JSON string).
/// </summary>
public class SensitiveStringJsonConverter : SensitiveStringJsonConverter<SensitiveString>
{
    public override SensitiveString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitive()!;
}