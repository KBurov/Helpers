using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_func.with_numberOfRetries_greater_than_zero
{
    public class when_call_Times : Context
    {
        [Fact]
        public void then_func_called_at_least_one_time()
        {
            Retry.Times(_simpleFunc, 1u);

            Assert.True(_funcCalled);
        }

        [Fact]
        public void then_func_called_exactly_numberOfRetries_times()
        {
            const uint numberOfRetries = 3u;

            Assert.Throws<Exception>(() => Retry.Times(_funcWithException, numberOfRetries));
            Assert.True(_funcCalled);
            Assert.Equal(numberOfRetries, _numberOfCalls);
        }
    }
}