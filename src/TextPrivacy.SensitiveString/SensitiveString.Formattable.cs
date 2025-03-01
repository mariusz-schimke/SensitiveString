namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IFormattable
{
    /// <summary>
    ///     Returns a string representation of the value with optional formatting.
    ///     The following formats are supported (case-insensitive):
    ///     <list type="bullet">
    ///         <item>
    ///             <description><c>R</c> – Reveals the original value.</description>
    ///         </item>
    ///         <item>
    ///             <description><c>M</c> or <c>null</c> – Masks the value with the default mask.</description>
    ///         </item>
    ///         <item>
    ///             <description><c>M:</c> – Applies a custom mask instead of the default one, e.g. <c>M:*</c> will return <c>*</c>.</description>
    ///         </item>
    ///     </list>
    ///     If the format is not recognized, an exception is thrown.
    /// </summary>
    /// <param name="format">
    ///     The format specifier.
    /// </param>
    /// <param name="formatProvider">
    ///     A format provider (currently unused).
    /// </param>
    /// <exception cref="FormatException">
    ///     Thrown when the format is not recognized.
    /// </exception>
    public string ToString(string? format, IFormatProvider? formatProvider = null)
    {
        return format?.ToLowerInvariant() switch
        {
            "r" => _getValue(), // revealed
            ['m', ':', .. var mask] => mask, // return the specified mask
            "m" or null => ToString(), // default masking
            _ => throw new FormatException($"The format '{format}' is not supported.")
        };
    }
}