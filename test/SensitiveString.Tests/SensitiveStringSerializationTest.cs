using SensitiveString.Json;
using MicrosoftSerialization = System.Text.Json;
using NewtonsoftSerialization = Newtonsoft.Json;

namespace SensitiveString.Tests;

public class SensitiveStringSerializationTest
{
    public static TheoryData<SensitiveString> TestData => new()
    {
        "sensitive value".AsSensitive(),
        "login@example.com".AsSensitiveEmail()
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void default_system_text_json_serialization_does_not_reveal_the_value(SensitiveString sensitiveValue)
    {
        var serialized = MicrosoftSerialization.JsonSerializer.Serialize(sensitiveValue);
        Assert.DoesNotContain(sensitiveValue.Reveal(), serialized);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void default_newtonsoft_json_serialization_does_not_reveal_the_value(SensitiveString sensitiveValue)
    {
        var serialized = NewtonsoftSerialization.JsonConvert.SerializeObject(sensitiveValue);
        Assert.DoesNotContain(sensitiveValue.Reveal(), serialized);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void system_text_json_serialization_preserves_the_value_when_custom_converters_applied(SensitiveString sensitiveValue)
    {
        var jsonOptions = CreateSensitiveStringSerializationOptions();

        var serialized = MicrosoftSerialization.JsonSerializer.Serialize(sensitiveValue, jsonOptions);
        Assert.Contains(sensitiveValue.Reveal(), serialized);

        var deserialized = MicrosoftSerialization.JsonSerializer.Deserialize<SensitiveString>(serialized, jsonOptions);
        Assert.Equal(sensitiveValue.Reveal(), deserialized!.Reveal());
    }

    private static MicrosoftSerialization.JsonSerializerOptions CreateSensitiveStringSerializationOptions() =>
        new()
        {
            Converters =
            {
                new SensitiveStringJsonConverter(),
                new SensitiveEmailJsonConverter()
            }
        };
}