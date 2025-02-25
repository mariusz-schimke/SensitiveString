namespace TextPrivacy.SensitiveString.Tests;

public class SensitiveStringConcatenationTest
{
    [Fact]
    public void sensitivestring_sensitivestring_concat()
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
        Assert.Null(concat);

        concat = s2 + s1;
        Assert.Null(concat);
    }

    [Fact]
    public void non_null_string_concat()
    {
        var s1 = "hello1".AsSensitive();
        var s2 = "hello2";

        var concat = s1 + s2;
        Assert.Equal("hello1hello2", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello2hello1", concat.Reveal());
    }

    [Fact]
    public void null_string_concat()
    {
        var s1 = "hello1".AsSensitive();
        string? s2 = null;

        var concat = s1 + s2;
        Assert.Equal("hello1", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello1", concat.Reveal());

        s1 = null;
        concat = s1 + s2;
        Assert.Null(concat);

        concat = s2 + s1;
        Assert.Null(concat);
    }

    [Fact]
    public void null1string_concat()
    {
        var s1 = "hello1".AsSensitive();
        string? s2 = null;

        var concat = s1 + s2;
        Assert.Equal("hello1", concat.Reveal());

        concat = s2 + s1;
        Assert.Equal("hello1", concat.Reveal());

        s1 = null;
        concat = s2 + s1;
        Assert.Null(concat);
    }
}