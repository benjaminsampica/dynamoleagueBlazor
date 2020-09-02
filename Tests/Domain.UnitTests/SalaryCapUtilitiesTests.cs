using Domain.Utilities;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.UnitTests
{
    [TestFixture]
    public class SalaryCapUtilitiesTests
    {
        [TestCase(2020, 1050)]
        [TestCase(2022, 1100)]
        [TestCase(2050, 1800)]
        public void GetCurrentCapValue_GivenYear_ReturnsCapValue(int year, int expectedCapValue)
            => SalaryCapUtilities.GetCurrentCapValue(year).Should().Be(expectedCapValue);
    }
}
