using FluentAssertions;
using System;
using System.Linq.Expressions;
using Tynamix.ObjectFiller;
using WebUI.Views.Bases.Navs;
using Xunit;

namespace WebUI.UnitTests.Views.Bases.Navs
{
    public class AnchorButtonBaseTests
    {
        [Fact]
        public void VerifyParameters_OutlineClass_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.OutlineClass, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_OutlineClass_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.OutlineClass, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_OutlineClass_WhenNotEmpty_DoesNotThrow()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.OutlineClass, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        [Fact]
        public void VerifyParameters_Title_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Title, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_Title_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Title, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_Title_WhenNotEmpty_DoesNotThrow()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Title, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        [Fact]
        public void VerifyParameters_Href_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Href, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_Href_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Href, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_Href_WhenNotEmpty_DoesNotThrow()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Href, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenEmpty_ThrowsArgumentException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Icon, string.Empty);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentException>();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenNull_ThrowsArgumentNullException()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Icon, null);

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void VerifyParameters_Icon_WhenNotEmpty_DoesNotThrow()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Icon, "Test");

            FluentActions.Invoking(() => sut.VerifyParameters()).Should().NotThrow();
        }

        [Fact]
        public void GetMargin_Text_IsNull_ReturnsEmptyString()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Text, null);

            sut.GetMargin().Should().BeEmpty();
        }

        [Fact]
        public void GetMargin_Text_IsEmpty_ReturnsEmptyString()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Text, string.Empty);

            sut.GetMargin().Should().BeEmpty();
        }

        [Fact]
        public void GetMargin_Text_IsNotEmpty_ReturnsMarginClass()
        {
            var sut = CreateFakeAnchorButtonBase(p => p.Text, "Test");

            sut.GetMargin().Should().NotBeNullOrEmpty();
        }


        private AnchorButtonBase CreateFakeAnchorButtonBase(Expression<Func<AnchorButtonBase, string>> property, string value)
        {
            var fakeObject = new Filler<AnchorButtonBase>();
            fakeObject.Setup().OnProperty(property).Use(value);
            return fakeObject.Create();
        }
    }
}
