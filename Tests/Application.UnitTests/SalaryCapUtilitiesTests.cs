using Domain.Utilities;
using FluentAssertions;
using Xunit;

namespace Application.UnitTests
{
    public class SalaryCapUtilitiesTests
    {
        [InlineData(2020, 1050)]
        [InlineData(2022, 1100)]
        [InlineData(2050, 1800)]
        [Theory]
        public void GetCurrentCapValue_GivenYear_ReturnsCapValue(int year, int expectedCapValue)
            => SalaryCapUtilities.GetCurrentCapValue(year).Should().Be(expectedCapValue);
    }
}
