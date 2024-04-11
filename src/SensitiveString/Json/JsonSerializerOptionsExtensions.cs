using System.Text.Json;

namespace SensitiveString.Json;

public static class JsonSerializerOptionsExtensions
{
    /// <summary>
    ///     Adds <see cref="SensitiveString" /> and <see cref="SensitiveEmail" /> to the serializer options.
    /// </summary>
    /// <param name="options">
    ///     The serializer options to add sensitive string support to.
    /// </param>
    public static void AddSensitiveStringSupport(this JsonSerializerOptions options)
    {
        options.Converters.Add(new SensitiveStringJsonConverter());
        options.Converters.Add(new SensitiveEmailJsonConverter());
    }
}