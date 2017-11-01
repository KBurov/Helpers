using Helpers.Common.Extensions;

using Ploeh.AutoFixture;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string.with_filled_EmptyValues
{
    public abstract class ContextWithEmptyValues : Context
    {
        protected override void SetUp()
        {
            base.SetUp();

            var fixture = new Fixture();

            StringExtensions.EmptyValues.Add(fixture.Create<string>());
        }
    }
}