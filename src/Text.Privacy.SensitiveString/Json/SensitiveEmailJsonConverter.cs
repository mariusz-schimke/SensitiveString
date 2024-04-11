using System.Text.Json;

namespace Text.Privacy.SensitiveString.Json;

/// <summary>
///     Enables proper JSON conversion of the <see cref="SensitiveString" /> type.
/// </summary>
public class SensitiveEmailJsonConverter : SensitiveStringJsonConverter<SensitiveEmail>
{
    public override SensitiveEmail Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString()?.AsSensitiveEmail()!;
}