#nullable disable

using FluentAssertions;

namespace SSuite.Extensions.Tests;

public class StringExtensionsTests
{
    [Theory]
    [InlineData(null, true)]
    [InlineData("", true)]
    [InlineData("   ", true)]
    [InlineData("abc", false)]
    public void IsNullOrEmptyOrWhiteSpace_ReturnsExpected(string input, bool expected)
    {
        bool result = input.IsNullOrEmptyOrWhiteSpace();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("", "")]
    [InlineData(null, null)]
    public void CapitalizeFirstLetter_ReturnsExpected(string input, string expected)
    {
        string result = input.CapitalizeFirstLetter();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("Hello", "hello")]
    [InlineData("hello", "hello")]
    [InlineData("", "")]
    [InlineData(null, null)]
    public void LowercaseFirstLetter_ReturnsExpected(string input, string expected)
    {
        string result = input.LowercaseFirstLetter();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(" H e l l o ", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("", "")]
    [InlineData(" ", "")]
    [InlineData(null, null)]
    public void RemoveWhitespace_ReturnsExpected(string input, string expected)
    {
        string result = input.RemoveWhitespace();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("ab", 3, "ababab")]
    [InlineData("a", 5, "aaaaa")]
    [InlineData("", 5, "")]
    [InlineData("ab", 0, "ab")]
    [InlineData("aaa", -1, "")]
    public void Repeat_ReturnsExpected(string input, int count, string expected)
    {
        if (count < 0)
        {
            Action action = () => input.Repeat(count);

            action.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("*Count cannot be less than 0*");
        }
        else
        {
            string result = input.Repeat(count);
            result.Should().Be(expected);
        }
    }

    [Theory]
    [InlineData("abcd", "dcba")]
    [InlineData("a", "a")]
    [InlineData("", "")]
    [InlineData(null, null)]
    public void Reverse_ReturnsExpected(string input, string expected)
    {
        string result = input.Reverse();
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("abcdef", 3, "abc")]
    [InlineData("abcdef", 6, "abcdef")]
    [InlineData("abcdef", 10, "abcdef")]
    [InlineData("", 3, "")]
    [InlineData(null, 3, null)]
    public void Truncate_ReturnsExpected(string input, int maxLength, string expected)
    {
        string result = input.Truncate(maxLength);
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("hello world", "Hello World")]
    [InlineData("HELLO WORLD", "Hello World")]
    [InlineData("hElLo WoRlD", "Hello World")]
    [InlineData("", "")]
    [InlineData(null, null)]
    public void ToTitleCase_ReturnsExpected(string input, string expected)
    {
        string result = input.ToTitleCase();
        result.Should().Be(expected);
    }
}
