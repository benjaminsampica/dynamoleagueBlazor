using FluentAssertions;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using WebUI.Views.Bases.Navs;
using Xunit;

namespace WebUI.UnitTests.Views.Bases.Navs
{
    public class PillBaseTests
    {
        [Fact]
        public void VerifyParameters_Text_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFake(p => p.Text, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_Text_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFake(p => p.Text, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_Text_WhenNotEmpty_IsValid()
        {
            var sut = CreateFake(p => p.Text, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFake(p => p.Icon, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFake(p => p.Icon, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenNotEmpty_IsValid()
        {
            var sut = CreateFake(p => p.Icon, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        private PillBase CreateFake(Expression<Func<PillBase, string>> property, string value)
        {
            var fakeObject = new Filler<PillBase>();
            fakeObject.Setup()
                .OnProperty(property).Use(value)
                .OnProperty(p => p.OnClickEventCallback).IgnoreIt();
            return fakeObject.Create();
        }
    }
}
