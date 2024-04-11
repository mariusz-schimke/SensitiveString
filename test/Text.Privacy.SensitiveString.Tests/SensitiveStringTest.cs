using System.Reflection;

namespace Text.Privacy.SensitiveString.Tests;

public class SensitiveStringTest
{
    [Fact]
    public void value_is_masked_when_accessed_by_to_string()
    {
        var input = Guid.NewGuid().ToString();
        var ss = input.AsSensitive();
        Assert.Equal("***", ss.ToString());
        Assert.NotEqual(input, ss.ToString());
    }

    [Fact]
    public void value_is_unmasked_when_accessed_by_a_dedicated_method()
    {
        var input = Guid.NewGuid().ToString();
        var ss = input.AsSensitive();
        Assert.Equal(input, ss.Reveal());
    }

    [Fact]
    public void value_is_unmasked_when_accessed_by_an_explicit_cast()
    {
        var input = Guid.NewGuid().ToString();
        var ss = input.AsSensitive();
        Assert.Equal(input, (string) ss);
    }

    [Fact]
    public void constructor_input_value_cannot_be_null()
    {
        var input = default(string);
        Assert.Throws<ArgumentNullException>(() =>
            {
                try
                {
                    Activator.CreateInstance(
                        type: typeof(SensitiveString),
                        bindingAttr: BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.CreateInstance,
                        binder: null,
                        args: [input],
                        culture: null
                    );
                }
                catch (TargetInvocationException e)
                {
                    throw e.InnerException!;
                }
            }
        );
    }

    [Fact]
    public void implicit_conversion_from_null_string_returns_null()
    {
        var input = default(string);
        var ss = input?.AsSensitive();
        Assert.Null(ss);
    }

    [Fact]
    public void implicit_conversion_from_null_sensitive_string_returns_null()
    {
        SensitiveString? ss = null;
        var value = (string) ss;
        Assert.Null(value);
    }

    [Fact]
    public void ordering_works_correctly_based_on_icomparable_generic()
    {
        string?[] strings = ["b", "a", "c", null];
        var sensitiveStrings = strings
           .Select(x => (SensitiveString?) x)
           .Order()
           .Select(x => x?.Reveal());

        Assert.Equal(strings.Order(), sensitiveStrings);
    }

    [Fact]
    public void ordering_works_correctly_based_on_icomparable_non_generic()
    {
        string?[] strings = ["b", "a", "c", null];
        var sensitiveStrings = strings
           .Select(x => (SensitiveString?) x)
           .Cast<object>()
           .Order()
           .Cast<SensitiveString>()
           .Select(x => x?.Reveal());

        Assert.Equal(strings.Order(), sensitiveStrings);
    }

    [Fact]
    public void equality_is_checked_by_string_content()
    {
        var ss1 = "same".AsSensitive();
        var ss2 = "same".AsSensitive();

        Assert.True(SensitiveString.Equals(ss1, ss2));

        Assert.True(ss1.Equals(ss2));
        Assert.True(ss1.Equals((object) ss2));

        Assert.True(ss1 == ss2);
        Assert.False(ss1 != ss2);
    }

    [Fact]
    public void equality_is_checked_by_string_content_with_comparison_type()
    {
        var ss1 = "same".AsSensitive();
        var ss2 = "SAME".AsSensitive();

        Assert.False(SensitiveString.Equals(ss1, ss2));
        Assert.True(SensitiveString.Equals(ss1, ss2, StringComparison.OrdinalIgnoreCase));

        Assert.False(ss1.Equals(ss2));
        Assert.False(ss1.Equals((object) ss2));
        Assert.True(ss1.Equals(ss2, StringComparison.OrdinalIgnoreCase));

        Assert.False(ss1 == ss2);
        Assert.True(ss1 != ss2);
    }

    [Fact]
    public void equality_is_checked_by_references_to_the_same_object()
    {
        var ss1 = "same".AsSensitive();
        var ss2 = ss1;

        Assert.True(SensitiveString.Equals(ss1, ss2));
        Assert.True(SensitiveString.Equals(ss1, ss2, StringComparison.OrdinalIgnoreCase));

        Assert.True(ss1.Equals(ss2));
        Assert.True(ss1.Equals((object) ss2));
        Assert.True(ss1.Equals(ss2, StringComparison.OrdinalIgnoreCase));

        Assert.True(ss1 == ss2);
        Assert.False(ss1 != ss2);
    }

    [Fact]
    public void equality_is_checked_by_both_null_references()
    {
        SensitiveString? ss1 = null;
        SensitiveString? ss2 = null;

        Assert.True(SensitiveString.Equals(ss1, ss2));
        Assert.True(SensitiveString.Equals(ss1, ss2, StringComparison.OrdinalIgnoreCase));

        Assert.True(ss1 == ss2);
        Assert.False(ss1 != ss2);
    }

    [Fact]
    public void equality_is_checked_by_one_null_reference()
    {
        var ss1 = "non-null".AsSensitive();
        SensitiveString? ss2 = null;

        Assert.False(ss1.Equals((object?) ss2));
        Assert.False(SensitiveString.Equals(ss1, ss2));
        Assert.False(SensitiveString.Equals(ss1, ss2, StringComparison.OrdinalIgnoreCase));

        Assert.False(ss1 == ss2);
        Assert.True(ss1 != ss2);
    }

    [Fact]
    public void equality_is_checked_by_sensitive_string_to_string_comparisons()
    {
        var input = "input";
        var ss = input.AsSensitive();

        Assert.True(input == ss);
        Assert.False(input != ss);

        Assert.True(ss == input);
        Assert.False(ss != input);
    }

    [Fact]
    public void object_hash_code_is_equal_to_the_string_content_hash_code()
    {
        var input = "input";
        var ss = input.AsSensitive();

        Assert.Equal(input.GetHashCode(), ss.GetHashCode());
    }
}