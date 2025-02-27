namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveStringFormattableTest
{
    [Fact]
    public void only_r_reveals_value()
    {
        var ss = "hello".AsSensitive();

        Assert.Equal(ss.Reveal(), $"{ss:R}");
        Assert.Equal(ss.Reveal(), $"{ss:r}");
        Assert.Equal(ss.ToString(), $"{ss}");
        Assert.Equal(ss.ToString(), $"{ss:xxx}");
    }

    [Fact]
    public void returns_custom_mask()
    {
        const string mask = "*masked*";
        var ss = "hello".AsSensitive();
        var email = "hello@example.com".AsSensitiveEmail();

        Assert.Equal(mask, $"{ss:M:*masked*}");
        Assert.Equal(mask, $"{ss:m:*masked*}");
        Assert.Equal("", $"{ss:m:}");
        Assert.Equal(mask, ss.ToString($"M:{mask}"));
        Assert.Equal(mask, email.ToString($"M:{mask}"));
    }
}