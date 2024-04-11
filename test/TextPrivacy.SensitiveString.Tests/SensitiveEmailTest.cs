namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveEmailTest
{
    [Fact]
    public void value_is_masked_when_accessed_by_to_string()
    {
        var input = "myemail@example.com";
        var ss = input.AsSensitiveEmail();
        Assert.Equal("***@example.com", ss.ToString());
    }

    [Fact]
    public void value_is_unmasked_when_accessed_by_a_dedicated_method()
    {
        var input = Guid.NewGuid().ToString();
        var ss = input.AsSensitiveEmail();
        Assert.Equal(input, ss.Reveal());
    }
}