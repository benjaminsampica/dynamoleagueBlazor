using FluentAssertions;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Xunit;

namespace Infrastructure.UnitTests.Identity
{
    public class IdentityResultExtensionsTests
    {
        [Fact]
        public void ToApplicationResult_WhenIdentityFailed_SetsSucceededToFalse_And_SetsOneError()
        {
            var sut = IdentityResult.Failed(new IdentityError { Description = "Failed." });

            sut.ToApplicationResult().Succeeded.Should().BeFalse();
            sut.ToApplicationResult().Errors.Should().HaveCount(1);
        }

        [Fact]
        public void ToApplicationResult_WhenIdentitySuccess_SetsSucceededToTrue_And_SetsZeroErrors()
        {
            var sut = IdentityResult.Success;

            sut.ToApplicationResult().Succeeded.Should().BeTrue();
            sut.ToApplicationResult().Errors.Should().BeEmpty();
        }
    }
}
