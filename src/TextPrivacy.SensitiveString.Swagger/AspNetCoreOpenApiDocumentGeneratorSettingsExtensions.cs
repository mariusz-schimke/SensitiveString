using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;
using NSwag.Generation.AspNetCore;

namespace TextPrivacy.SensitiveString.Swagger;

public static class AspNetCoreOpenApiDocumentGeneratorSettingsExtensions
{
    /// <summary>
    ///     Adds proper type mapping to Swagger documentation for the sensitive string types.
    /// </summary>
    /// <param name="settings">
    ///     The Swagger documentation generator settings.
    /// </param>
    public static void AddSensitiveStringSupport(this AspNetCoreOpenApiDocumentGeneratorSettings settings)
    {
        settings.SchemaSettings.TypeMappers.Add(new ObjectTypeMapper(typeof(SensitiveString), JsonSchema.FromType<string>()));
        settings.SchemaSettings.TypeMappers.Add(new ObjectTypeMapper(typeof(SensitiveEmail), JsonSchema.FromType<string>()));
    }
}