using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_action.with_numberOfRetries_greater_than_zero
{
    public class when_call_Times : Context
    {
        [Fact]
        public void then_action_called_at_least_one_time()
        {
            Retry.Times(_simpleAction, 1u);

            Assert.True(_actionCalled);
        }

        [Fact]
        public void then_action_called_exactly_numberOfRetries_times()
        {
            const uint numberOfRetries = 3u;

            Assert.Throws<Exception>(() => Retry.Times(_actionWithException, numberOfRetries));
            Assert.True(_actionCalled);
            Assert.Equal(numberOfRetries, _numberOfCalls);
        }
    }
}