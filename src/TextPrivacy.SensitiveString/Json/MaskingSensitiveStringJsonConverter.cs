using System.Text.Json;
using System.Text.Json.Serialization;

namespace TextPrivacy.SensitiveString.Json;

/// <summary>
///     Enables support for descendants of the <see cref="SensitiveString" /> type. The original value wrapped by them is masked on
///     object serialization (the original value does not appear in the output JSON string). On deserialization, the parsed value is
///     read as it is and wrapped by the <see cref="SensitiveString" /> type.
/// </summary>
/// <remarks>
///     An example use case may be the observability context where you don't want to reveal the wrapped value, but want the type to
///     be mapped to string rather than an empty object.
/// </remarks>
public abstract class MaskingSensitiveStringJsonConverter<TSensitiveString> : JsonConverter<TSensitiveString>
    where TSensitiveString : SensitiveString
{
    public abstract override TSensitiveString? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options);

    public override void Write(Utf8JsonWriter writer, TSensitiveString value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

/// <summary>
///     Enables support for the <see cref="SensitiveString" /> type. The original value wrapped by it is masked on object
///     serialization (the original value does not appear in the output JSON string). On deserialization, the parsed value is read as
///     it is and wrapped by the <see cref="SensitiveString" /> type.
/// </summary>
/// <remarks>
///     An example use case may be the observability context where you don't want to reveal the wrapped value, but want the type to
///     be mapped to string rather than an empty object.
/// </remarks>
public class MaskingSensitiveStringJsonConverter : MaskingSensitiveStringJsonConverter<SensitiveString>
{
    public override SensitiveString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitive()!;
}