using AutoFixture;

namespace Application.UnitTests.Common.AutoFixture
{
    internal static class Utilities
    {
        public static IFixture GetFixture() => new Fixture().Customize(new IgnoreClassMembersCustomization());
    }
}
