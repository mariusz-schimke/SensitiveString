using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;

namespace TextPrivacy.SensitiveString.HotChocolate;

public static class SensitiveStringExtensions
{
    /// <summary>
    ///     Adds filtering support for the sensitive string types.
    /// </summary>
    /// <param name="descriptor">
    ///     The filtering descriptor.
    /// </param>
    /// <example>
    ///     .AddFiltering(x => x.AddDefaults().AddSensitiveString())
    /// </example>
    public static IFilterConventionDescriptor AddSensitiveStringSupport(this IFilterConventionDescriptor descriptor)
    {
        descriptor
           .BindRuntimeType<SensitiveString, StringOperationFilterInputType>()
           .BindRuntimeType<SensitiveEmail, StringOperationFilterInputType>();
        return descriptor;
    }

    /// <summary>
    ///     Adds sorting support for the sensitive string types.
    /// </summary>
    /// <param name="descriptor">
    ///     The sorting descriptor.
    /// </param>
    /// <example>
    ///     .AddSorting(x => x.AddDefaults().AddSensitiveString())
    /// </example>
    public static ISortConventionDescriptor AddSensitiveStringSupport(this ISortConventionDescriptor descriptor)
    {
        descriptor
           .BindRuntimeType<SensitiveString, DefaultSortEnumType>()
           .BindRuntimeType<SensitiveEmail, DefaultSortEnumType>();
        return descriptor;
    }

    /// <summary>
    ///     Adds sensitive string support to GraphQL types.
    /// </summary>
    /// <param name="builder">
    ///     The builder.
    /// </param>
    public static IRequestExecutorBuilder AddSensitiveStringSupport(this IRequestExecutorBuilder builder)
    {
        builder.BindRuntimeType<SensitiveString, StringType>()
           .AddTypeConverter<SensitiveString, string>(x => (string) x)
           .AddTypeConverter<string, SensitiveString>(x => x.AsSensitive());

        builder.BindRuntimeType<SensitiveEmail, StringType>()
           .AddTypeConverter<SensitiveEmail, string>(x => (string) x)
           .AddTypeConverter<string, SensitiveEmail>(x => x.AsSensitiveEmail());

        return builder;
    }
}