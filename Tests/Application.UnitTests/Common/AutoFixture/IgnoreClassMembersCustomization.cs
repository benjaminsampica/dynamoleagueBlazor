using AutoFixture;
using AutoFixture.Kernel;
using System;
using System.Reflection;

namespace Application.UnitTests.Common.AutoFixture
{
    internal class IgnoreClassMembersCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new IgnoreClassMembersSpecimenBuilder());
        }
    }

    internal class IgnoreClassMembersSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var pi = request as PropertyInfo;
            if (pi == null)
            {
                return new NoSpecimen();
            }

            if (pi.GetType().IsClass)
            {
                return null;
            }

            if (pi.GetType().IsInterface)
            {
                return null;
            }
            return new NoSpecimen();
        }
    }
}
