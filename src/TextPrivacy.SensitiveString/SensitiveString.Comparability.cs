namespace TextPrivacy.SensitiveString;

public partial class SensitiveString : IComparable<SensitiveString>, IComparable
{
    /// <inheritdoc cref="IComparable" />
    public int CompareTo(object? obj) => CompareTo((SensitiveString?) obj);

    /// <inheritdoc cref="IComparable{T}" />
    public int CompareTo(SensitiveString? other) => string.CompareOrdinal(_getValue(), other?._getValue());
}