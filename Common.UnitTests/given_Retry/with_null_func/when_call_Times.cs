using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_Retry.with_null_func
{
    public class when_call_Times
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => Retry.Times((Func<int>) null, 1u));
        }
    }
}