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

        Assert.Equal(mask, $"{ss:M:*masked*}");
        Assert.Equal(mask, $"{ss:m:*masked*}");
        Assert.Equal(mask, ss.ToString($"M:{mask}"));
    }
}