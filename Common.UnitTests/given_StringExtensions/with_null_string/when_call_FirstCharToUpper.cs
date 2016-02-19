using System;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_null_string
{
    public class when_call_FirstCharToUpper : Context
    {
        [Fact]
        public void then_then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => _str.FirstCharToUpper());
        }
    }
}