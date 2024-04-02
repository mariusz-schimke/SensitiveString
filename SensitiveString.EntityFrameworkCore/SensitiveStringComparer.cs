using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SensitiveString.EntityFrameworkCore;

public class SensitiveStringComparer : ValueComparer<SensitiveString>
{
    public SensitiveStringComparer()
        : base(
            (a, b) => SensitiveString.Equals(a, b),
            sensitiveString => sensitiveString.GetHashCode())
    {
    }
}