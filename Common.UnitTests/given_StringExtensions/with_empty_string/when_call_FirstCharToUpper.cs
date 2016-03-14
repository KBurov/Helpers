using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_empty_string
{
    public class when_call_FirstCharToUpper : Context
    {
        [Fact]
        public void then_returns_empty_string()
        {
            var result = _str.FirstCharToUpper();

            Assert.Empty(result);
        }
    }
}