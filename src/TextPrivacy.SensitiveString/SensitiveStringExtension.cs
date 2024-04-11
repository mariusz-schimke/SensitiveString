using System.Diagnostics.Contracts;

namespace TextPrivacy.SensitiveString;

public static class SensitiveStringExtension
{
    /// <summary>
    ///     Converts the input string to <see cref="SensitiveString" />;
    /// </summary>
    /// <param name="input">
    ///     The input string to convert.
    /// </param>
    [Pure]
    public static SensitiveString AsSensitive(this string input) => SensitiveString.FromString(input);

    /// <summary>
    ///     Converts the input email string to <see cref="SensitiveEmail" />;
    /// </summary>
    /// <param name="email">
    ///     The input email string to convert.
    /// </param>
    [Pure]
    public static SensitiveEmail AsSensitiveEmail(this string email) => SensitiveEmail.FromString(email);
}