namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IFormattable
{
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return format switch
        {
            "R" => _getValue(), // revealed
            _ => ToString() // masked by default
        };
    }
}