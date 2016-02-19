using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_empty_string
{
    public class when_call_IsUInt : Context
    {
        [Fact]
        public void then_returns_false()
        {
            var result = _str.IsUInt();

            Assert.False(result);
        }
    }
}