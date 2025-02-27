namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveStringConcatenationTest
{
    [Fact]
    public void sensitive_string_sensitive_string_concat()
    {
        var s1 = "hello1".AsSensitive();
        var s2 = "hello2".AsSensitive();

        var concat = s1 + s2;
        Assert.Equal("hello1hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2hello1", concat.Reveal());

        s1 = null;
        concat = s1 + s2;
        Assert.Equal("hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2", concat.Reveal());

        s2 = null;
        concat = s1 + s2;
        Assert.Empty(concat.Reveal());

        concat = s2 + s1;
        Assert.Empty(concat.Reveal());
    }

    [Fact]
    public void sensitive_string_string_concat()
    {
        var s1 = "hello1".AsSensitive();
        var s2 = "hello2";

        var concat = s1 + s2;
        Assert.Equal("hello1hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2hello1", concat.Reveal());

        s1 = null;
        concat = s1 + s2;
        Assert.Equal("hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2", concat.Reveal());

        s2 = null;
        concat = s1 + s2;
        Assert.Empty(concat.Reveal());

        concat = s2 + s1;
        Assert.Empty(concat.Reveal());
    }

    [Fact]
    public void sensitive_string_object_concat()
    {
        var s1 = "hello1".AsSensitive();
        object? s2 = "hello2";

        var concat = s1 + s2;
        Assert.Equal("hello1hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2hello1", concat.Reveal());

        s1 = null;
        concat = s1 + s2;
        Assert.Equal("hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2", concat.Reveal());

        s2 = null;
        concat = s1 + s2;
        Assert.Empty(concat.Reveal());

        concat = s2 + s1;
        Assert.Empty(concat.Reveal());
    }
}