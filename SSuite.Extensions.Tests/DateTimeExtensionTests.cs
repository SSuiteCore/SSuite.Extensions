using FluentAssertions;

namespace SSuite.Extensions.Tests;

public class DateTimeExtensionTests
{
    [Theory]
    [InlineData(25)]
    [InlineData(14)]
    [InlineData(40)]
    public void GetAgeInYears_ReturnsExpected(int expected)
    {
        
        DateTime dateOfBirth = DateTime.Today.AddYears(-expected);
        
        int result = dateOfBirth.GetAgeInYears();

        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData(22)]
    [InlineData(14)]
    [InlineData(43)]
    public void GetAgeInMonths_ReturnsCorrectAgeInMonths(int years)
    {

        DateTime dateOfBirth = DateTime.Today.AddYears(-years);

        int result = dateOfBirth.GetAgeInMonths();

        result.Should().Be(years * 12);
    }
    
}