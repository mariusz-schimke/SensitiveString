namespace TextPrivacy.SensitiveString;

// remark: two concatenated null strings result in an empty string!
public partial class SensitiveString
{
    public static SensitiveString operator +(SensitiveString? left, SensitiveString? right) => new(left?.Reveal() + right?.Reveal());

    public static SensitiveString operator +(SensitiveString? left, string? right) => new(left?.Reveal() + right);
    public static SensitiveString operator +(string? left, SensitiveString? right) => new(left + right?.Reveal());

    public static SensitiveString operator +(SensitiveString? left, object? right) => new(left?.Reveal() + right);
    public static SensitiveString operator +(object? left, SensitiveString? right) => new(left + right?.Reveal());
}