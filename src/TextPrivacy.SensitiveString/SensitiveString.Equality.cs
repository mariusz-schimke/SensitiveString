namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IEquatable<SensitiveString>
{
    /// <inheritdoc cref="IEquatable{T}" />
    public bool Equals(SensitiveString? other) => Equals(this, other);

    /// <summary>
    ///     Determines whether this instance and a specified string have the same value. A parameter specifies the culture, case, and
    ///     sort rules used in the comparison.
    /// </summary>
    /// <param name="other">
    ///     The other instance to compare to this one.
    /// </param>
    /// <param name="comparisonType">
    ///     One of the enumeration values that specifies how the strings will be compared.
    /// </param>
    public bool Equals(SensitiveString? other, StringComparison comparisonType) => Equals(this, other, comparisonType);

    /// <summary>
    ///     Determines whether the two instances have the same value.
    /// </summary>
    /// <param name="a">
    ///     The first string to compare, or null
    /// </param>
    /// <param name="b">
    ///     The second string to compare, or null
    /// </param>
    public static bool Equals(SensitiveString? a, SensitiveString? b) =>
        TryGetEqualityByReferences(a, b, out var equal)
            ? equal
            : string.Equals(a?._getValue(), b?._getValue());

    /// <summary>
    ///     Determines whether the two instances have the same value. A parameter specifies the culture, case, and sort rules used in the
    ///     comparison.
    /// </summary>
    /// <param name="a">
    ///     The first string to compare, or null
    /// </param>
    /// <param name="b">
    ///     The second string to compare, or null
    /// </param>
    /// <param name="comparisonType">
    ///     One of the enumeration values that specifies the rules for the comparison.
    /// </param>
    public static bool Equals(SensitiveString? a, SensitiveString? b, StringComparison comparisonType) =>
        TryGetEqualityByReferences(a, b, out var equal)
            ? equal
            : string.Equals(a?._getValue(), b?._getValue(), comparisonType);

    public override bool Equals(object? obj) => obj is SensitiveString other && Equals(other);

    private static bool TryGetEqualityByReferences(SensitiveString? a, SensitiveString? b, out bool equal)
    {
        // only one side is null
        if (ReferenceEquals(a, null) ^ ReferenceEquals(b, null))
        {
            equal = false;
            return true;
        }

        // both sides are null or both sides are the same object
        if (ReferenceEquals(a, b))
        {
            equal = true;
            return true;
        }

        // can't determine equality by references
        equal = false;
        return false;
    }

    /// <summary>
    ///     Checks whether the string contents of the compared instances are equal.
    /// </summary>
    /// <param name="a">
    ///     The first instance to compare.
    /// </param>
    /// <param name="b">
    ///     The second instance to compare.
    /// </param>
    public static bool operator ==(SensitiveString? a, SensitiveString? b) => Equals(a, b);

    /// <summary>
    ///     Checks whether the string contents of the compared instances are unequal.
    /// </summary>
    /// <param name="a">
    ///     The first instance to compare.
    /// </param>
    /// <param name="b">
    ///     The second instance to compare.
    /// </param>
    public static bool operator !=(SensitiveString? a, SensitiveString? b) => !(a == b);

    public static bool operator ==(SensitiveString? a, string? b) => a?._getValue() == b;
    public static bool operator !=(SensitiveString? a, string? b) => !(a == b);

    public static bool operator ==(string? a, SensitiveString? b) => a == b?._getValue();
    public static bool operator !=(string? a, SensitiveString? b) => !(a == b);
}