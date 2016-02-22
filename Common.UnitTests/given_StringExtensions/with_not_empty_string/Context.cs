using Helpers.TestFramework;

using Ploeh.AutoFixture;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string
{
    public abstract class Context : ContextBase
    {
        protected string _sut;

        protected override void SetUp()
        {
            base.SetUp();

            var fixture = new Fixture();

            _sut = fixture.Create<string>();
        }
    }
}