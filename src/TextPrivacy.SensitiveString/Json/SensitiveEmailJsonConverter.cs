using System.Text.Json;

namespace TextPrivacy.SensitiveString.Json;

/// <summary>
///     Enables support for the <see cref="SensitiveEmail" /> type. The original value wrapped by it is revealed on object
///     serialization (the original value appears in the output JSON string).
/// </summary>
public class SensitiveEmailJsonConverter : SensitiveStringJsonConverter<SensitiveEmail>
{
    public override SensitiveEmail? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitiveEmail();
}