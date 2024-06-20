
using System.Globalization;

namespace SSuite.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmptyOrWhiteSpace(this string? str)
        => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);

    public static string? CapitalizeFirstLetter(this string? str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        return string.Create(str.Length, str, (span, result) =>
        {
            result.AsSpan(0).CopyTo(span[..]);
            span[0] = char.ToUpper(result[0]);
        });
    }

    public static string? LowercaseFirstLetter(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;

        return string.Create(str.Length, str, (span, result) =>
        {
            result.AsSpan(0).CopyTo(span[..]);
            span[0] = char.ToLower(result[0]);
        });
    }

    public static string? RemoveWhitespace(this string? str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        
        int count = str.Count(c => !char.IsWhiteSpace(c));
        
        return string.Create(count, str, (span, value) =>
        {
            int index = 0;
            foreach (char c in value)
            {
                if (!char.IsWhiteSpace(c))
                    span[index++] = c;
            }
        });
    }

    public static string? Repeat(this string? str, int count)
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be less than 0");
        
        if (string.IsNullOrEmpty(str) || count == 0)
            return str;
        
        return string.Concat(Enumerable.Repeat(str, count));
    }

    public static string? Reverse(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return str;

        return string.Create(str.Length, str, (span, result) =>
        {
            for (int i = 0; i < result.Length; i++)
            {
                span[i] = result[result.Length - 1 - i];
            }
        });
    }

    public static string? Truncate(this string? str, int maxLength)
    {
        if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
            return str;
        
        return str.Substring(0, maxLength);
    }

    public static string? ToTitleCase(this string? str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
        
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
    }
}