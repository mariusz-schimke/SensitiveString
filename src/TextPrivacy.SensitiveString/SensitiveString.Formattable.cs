namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return format?.ToLowerInvariant() switch
        {
            "r" => _getValue(), // revealed
            { Length: > 2 } f when f.StartsWith("m:") => format[2..], // return the specified mask
            _ => ToString() // default masking
        };
    }

    public string ToString(string? format) => ToString(format, formatProvider: null);
}