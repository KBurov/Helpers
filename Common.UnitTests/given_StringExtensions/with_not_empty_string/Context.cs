using Helpers.TestFramework;

using Ploeh.AutoFixture;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string
{
    public abstract class Context : ContextBase
    {
        protected string _str;

        protected override void SetUp()
        {
            base.SetUp();

            var fixture = new Fixture();

            _str = fixture.Create<string>();
        }
    }
}