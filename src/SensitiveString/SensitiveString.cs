using System.Diagnostics.Contracts;

namespace SensitiveString;

/// <summary>
///     Encloses a string value in an object to protect it from being written to logs or serialized unintentionally.
/// </summary>
public partial class SensitiveString
{
    protected const string DefaultMask = "***";

    /// <summary>
    ///     The value is accessible only through a function call here to mitigate the risk of it's being serialized by a serializer whose
    ///     configuration causes it to include private fields.
    /// </summary>
    private readonly Func<string> _getValue;

    /// <summary>
    ///     Creates a new sensitive string instance.
    /// </summary>
    /// <param name="value">
    ///     The input string to protect.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the input string is null.
    /// </exception>
    protected SensitiveString(string value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value), "The input sensitive string cannot be null");
        }

        _getValue = () => value;
    }

    /// <summary>
    ///     Returns an empty sensitive string.
    /// </summary>
    public static SensitiveString Empty { get; } = new(string.Empty);

    /// <summary>
    ///     Gets the original string value.
    /// </summary>
    [Pure]
    public string Reveal() => _getValue();

    /// <summary>
    ///     Masks the specified value.
    /// </summary>
    /// <param name="value">
    ///     The value to mask.
    /// </param>
    [Pure]
    protected virtual string Mask(string value) => DefaultMask;

    /// <summary>
    ///     Returns a masked value.
    /// </summary>
    public override string ToString() => Mask(_getValue());

    public override int GetHashCode() => _getValue().GetHashCode();

    /// <summary>
    ///     Returns a string with the original value.
    /// </summary>
    /// <param name="source">
    ///     The sensitive string whose original value to return.
    /// </param>
    public static explicit operator string(SensitiveString? source) => source?._getValue()!;

    /// <summary>
    ///     Converts a string to a sensitive string.
    /// </summary>
    /// <param name="source">
    ///     The string to convert.
    /// </param>
    /// <remarks>
    ///     Only the explicit conversion is implemented here to make sure there are no unintentional/unnoticed implicit conversions in
    ///     the code where in fact the source string converted should be the sensitive type in the first place.
    /// </remarks>
    public static explicit operator SensitiveString(string? source) => FromString(source);

    /// <summary>
    ///     Returns an instance initialized with the specified string. If the string is null, returns null.
    /// </summary>
    /// <param name="input">
    ///     The input string to initialize the instance with.
    /// </param>
    public static SensitiveString FromString(string? input) => input is null ? null! : new(input);
}