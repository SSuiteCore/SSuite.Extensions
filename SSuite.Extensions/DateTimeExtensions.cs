namespace SSuite.Extensions;

public static class DateTimeExtensions
{
    public static int GetAgeInYears(this DateTime dateOfBirth)
    {
        var today = DateTime.Today;
        int age = today.Year - dateOfBirth.Year;

        if (dateOfBirth.Date > today.AddYears(-age))
        {
            age -= 1;
        }
        return age;
    }
    public static int GetAgeInMonths(this DateTime dateOfBirth)
    {
        DateTime today = DateTime.Today;
        int years = today.Year - dateOfBirth.Year;
        int months = today.Month - dateOfBirth.Month;

        if (months < 0)
        {
            years -= 1;
            months += 12;
        }

        int result = years * 12 + months;

        if (today.Day < dateOfBirth.Day)
        {
            result -= 1;
        }

        return result;
    }
}