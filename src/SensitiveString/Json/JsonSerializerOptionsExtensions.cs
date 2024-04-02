using System.Text.Json;

namespace SensitiveString.Json;

public static class JsonSerializerOptionsExtensions
{
    public static void AddSensitiveStringSupport(this JsonSerializerOptions options)
    {
        options.Converters.Add(new SensitiveStringJsonConverter());
        options.Converters.Add(new SensitiveEmailJsonConverter());
    }
}