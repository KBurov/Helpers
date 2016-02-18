using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_func.with_numberOfRetries_equal_zero
{
    public class when_call_Times : Context
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentException>(() => Retry.Times(_simpleFunc, 0u));
            Assert.False(_funcCalled);
        }
    }
}