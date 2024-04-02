using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SensitiveString.EntityFrameworkCore;

public class SensitiveEmailConverter : ValueConverter<SensitiveEmail, string>
{
    public SensitiveEmailConverter()
        : base(
            sensitiveEmail => (string) sensitiveEmail,
            sensitiveEmail => sensitiveEmail.AsSensitiveEmail())
    {
    }
}