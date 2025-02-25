using System.Diagnostics.CodeAnalysis;

namespace TextPrivacy.SensitiveString;

/// <summary>
///     Encloses a string value in an object to protect it from being written to logs or serialized unintentionally. Provides custom
///     email masking capabilities.
/// </summary>
public class SensitiveEmail : SensitiveString
{
    private SensitiveEmail(string value)
        : base(value)
    {
    }

    /// <summary>
    ///     Returns an empty sensitive email string.
    /// </summary>
    public new static SensitiveEmail Empty { get; } = new(string.Empty);

    protected override string Mask(string value) => value.LastIndexOf('@') is var index && index >= 0
        ? $"{DefaultMask}{value[index..]}"
        : base.Mask(value);

    /// <summary>
    ///     Returns an instance initialized with the specified email string. If the string is null, returns null.
    /// </summary>
    /// <param name="input">
    ///     The input email string to initialize the instance with.
    /// </param>
    [return: NotNullIfNotNull(nameof(input))]
    public new static SensitiveEmail? FromString(string? input) => input is null ? null : new SensitiveEmail(input);

    /// <summary>
    ///     Converts an email string to a sensitive email string.
    /// </summary>
    /// <param name="source">
    ///     The email string to convert.
    /// </param>
    /// <remarks>
    ///     Only the explicit conversion is implemented here to make sure there are no unintentional/unnoticed implicit conversions in
    ///     the code where in fact the source string converted should be the sensitive type in the first place.
    /// </remarks>
    [return: NotNullIfNotNull(nameof(source))]
    public static explicit operator SensitiveEmail?(string? source) => FromString(source);

    /// <summary>
    ///     Returns a string with the original value.
    /// </summary>
    /// <param name="source">
    ///     The sensitive string whose original value to return.
    /// </param>
    /// <remarks>
    ///     Although this method may appear redundant since the base class provides the same functionality, it is necessary in scenarios
    ///     where the operator is resolved via reflection on the current type rather than including its base type. This can occur in
    ///     frameworks like FluentValidation.
    /// </remarks>
    public static explicit operator string?(SensitiveEmail? source) => source?.Reveal();
}