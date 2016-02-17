using Xunit;

namespace Helpers.Common.UnitTests.given_DisposeAction.with_not_null_action
{
    public sealed class when_dispose_DisposeAction : Context
    {
        [Fact]
        public void then_action_called()
        {
            using (_disposeAction) {}

            Assert.True(_actionCalled);
        }
    }
}