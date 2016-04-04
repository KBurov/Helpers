using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_empty_string
{
    public class when_call_SimpleReverse : Context
    {
        [Fact]
        public void then_returns_empty_string()
        {
            var result = _str.SimpleReverse();

            Assert.Empty(result);
        }
    }
}