using System.Text.Json;

namespace TextPrivacy.SensitiveString.Json;

/// <summary>
///     Enables support for the <see cref="SensitiveEmail" /> type. The original value wrapped by it is masked on object
///     serialization (the original value does not appear in the output JSON string). On deserialization, the parsed value is read as
///     it is and wrapped by the <see cref="SensitiveEmail" /> type.
/// </summary>
/// <remarks>
///     An example use case may be the observability context where you don't want to reveal the wrapped value, but want the type to
///     be mapped to string rather than an empty object.
/// </remarks>
public class MaskingSensitiveEmailJsonConverter : MaskingSensitiveStringJsonConverter<SensitiveEmail>
{
    public override SensitiveEmail? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitiveEmail();
}