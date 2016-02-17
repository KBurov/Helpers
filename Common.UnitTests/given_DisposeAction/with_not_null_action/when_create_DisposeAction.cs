using Xunit;

namespace Helpers.Common.UnitTests.given_DisposeAction.with_not_null_action
{
    public sealed class when_create_DisposeAction : Context
    {
        [Fact]
        public void then_DisposeAction_created()
        {
            Assert.NotNull(_disposeAction);
        }
    }
}