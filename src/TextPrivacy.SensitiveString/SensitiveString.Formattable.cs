namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IFormattable
{
    /// <summary>
    ///     Returns a string representation of the value with optional formatting.
    ///     The following formats are supported:
    ///     <list type="bullet">
    ///         <item>
    ///             <description><c>R</c> – Reveals the original value.</description>
    ///         </item>
    ///         <item>
    ///             <description><c>M:</c> – Applies a custom mask instead of the default one, e.g. <c>M:*****</c>.</description>
    ///         </item>
    ///     </list>
    ///     If the format is not recognized, the default masking is applied, and the value remains hidden.
    /// </summary>
    /// <param name="format">
    ///     The format specifier.
    /// </param>
    /// <param name="formatProvider">
    ///     A format provider (currently unused).
    /// </param>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return format?.ToLowerInvariant() switch
        {
            "r" => _getValue(), // revealed
            ['m', ':', .. var mask] => mask, // return the specified mask
            _ => ToString() // default masking
        };
    }

    /// <inheritdoc cref="ToString(string?,System.IFormatProvider?)" />
    public string ToString(string? format) => ToString(format, formatProvider: null);
}