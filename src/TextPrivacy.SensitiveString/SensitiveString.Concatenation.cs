namespace TextPrivacy.SensitiveString;

// remark: two concatenated null strings result in an empty string!
public partial class SensitiveString
{
    public static SensitiveString operator +(SensitiveString? left, SensitiveString? right) => new(left?._getValue() + right?._getValue());

    public static SensitiveString operator +(SensitiveString? left, string? right) => new(left?._getValue() + right);
    public static SensitiveString operator +(string? left, SensitiveString? right) => new(left + right?._getValue());

    public static SensitiveString operator +(SensitiveString? left, object? right) => new(left?._getValue() + right);
    public static SensitiveString operator +(object? left, SensitiveString? right) => new(left + right?._getValue());
}