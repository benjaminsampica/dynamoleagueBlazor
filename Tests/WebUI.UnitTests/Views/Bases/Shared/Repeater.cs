using Bunit;
using Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using WebUI.Views.Bases.Shared;
using Xunit;

namespace WebUI.UnitTests.Views.Bases.Shared
{
    public class RepeaterTests : TestContext
    {
        [Fact]
        public void VerifyParameters_Items_WhenNull_ThrowsArgumentNullException()
        {
            FluentActions.Invoking(() =>
                RenderComponent<Repeater<Team>>(p =>
                    p.Add(c => c.Items, null)
                    .Add(c => c.ItemTemplate, item => string.Empty))
            )
            .Should().Throw<ArgumentNullException>()
            .And.ParamName
            .Should().Be(nameof(Repeater<Team>.Items));
        }

        [Fact]
        public void VerifyParameters_ItemTemplate_WhenNull_ThrowsArgumentNullException()
        {
            FluentActions.Invoking(() =>
                RenderComponent<Repeater<Team>>(p =>
                    p.Add(c => c.Items, new List<Team>()))
            )
            .Should().Throw<ArgumentNullException>()
            .And.ParamName
            .Should().Be(nameof(Repeater<Team>.ItemTemplate));
        }
    }
}
