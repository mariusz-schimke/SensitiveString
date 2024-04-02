using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SensitiveString.EntityFrameworkCore;

public class SensitiveStringConverter : ValueConverter<SensitiveString, string>
{
    public SensitiveStringConverter()
        : base(
            sensitiveString => (string) sensitiveString,
            sensitiveString => sensitiveString.AsSensitive())
    {
    }
}