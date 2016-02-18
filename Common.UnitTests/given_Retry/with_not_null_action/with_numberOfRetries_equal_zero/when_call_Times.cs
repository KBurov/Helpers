using Xunit;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_action.with_numberOfRetries_equal_zero
{
    public class when_call_Times : Context
    {
        [Fact]
        public void then_action_does_not_called()
        {
            Retry.Times(_simpleAction, 0u);

            Assert.False(_actionCalled);
        }
    }
}