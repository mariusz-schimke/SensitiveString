using System.Diagnostics.CodeAnalysis;

namespace TextPrivacy.SensitiveString;

public partial class SensitiveString
{
    [return: NotNullIfNotNull(nameof(left))]
    [return: NotNullIfNotNull(nameof(right))]
    public static SensitiveString? operator +(SensitiveString? left, SensitiveString? right) =>
        left?.Reveal() + right?.Reveal() is { } output
            ? new SensitiveString(output)
            : null;

    #region string

    [return: NotNullIfNotNull(nameof(left))]
    [return: NotNullIfNotNull(nameof(right))]
    public static SensitiveString? operator +(SensitiveString? left, string? right) =>
        left?.Reveal() + right is { } output
            ? new SensitiveString(output)
            : null;

    [return: NotNullIfNotNull(nameof(left))]
    [return: NotNullIfNotNull(nameof(right))]
    public static SensitiveString? operator +(string? left, SensitiveString? right) =>
        left + right?.Reveal() is { } output
            ? new SensitiveString(output)
            : null;

    #endregion

    #region object

    [return: NotNullIfNotNull(nameof(left))]
    [return: NotNullIfNotNull(nameof(right))]
    public static SensitiveString? operator +(SensitiveString? left, object? right) =>
        left?.Reveal() + right is { } output
            ? new SensitiveString(output)
            : null;

    [return: NotNullIfNotNull(nameof(left))]
    [return: NotNullIfNotNull(nameof(right))]
    public static SensitiveString? operator +(object? left, SensitiveString? right) =>
        left + right?.Reveal() is { } output
            ? new SensitiveString(output)
            : null;

    #endregion
}