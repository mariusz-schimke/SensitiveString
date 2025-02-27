namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveStringFormattableTest
{
    [Fact]
    public void only_r_reveals_value()
    {
        var ss = "hello".AsSensitive();
        var revealed = $"{ss:R}";
        var masked = $"{ss}";
        var unsupported = $"{ss:xxx}";

        Assert.Equal(ss.Reveal(), revealed);
        Assert.Equal(ss.ToString(), masked);
        Assert.Equal(ss.ToString(), unsupported);
    }
}