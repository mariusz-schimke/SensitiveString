using Microsoft.EntityFrameworkCore;

namespace SensitiveString.EntityFrameworkCore;

public static class SensitiveStringExtensions
{
    public static ModelConfigurationBuilder AddSensitiveStringSupport(this ModelConfigurationBuilder builder)
    {
        builder.Properties<SensitiveString>()
           .HaveConversion<SensitiveStringConverter, SensitiveStringComparer>();

        builder.Properties<SensitiveEmail>()
           .HaveConversion<SensitiveEmailConverter, SensitiveStringComparer>();

        return builder;
    }
}