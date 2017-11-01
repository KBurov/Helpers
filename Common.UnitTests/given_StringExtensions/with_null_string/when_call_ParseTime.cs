using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_null_string
{
    public class when_call_ParseTime : Context
    {
        [Fact]
        public void then_returns_null()
        {
            var result = _str.ParseTime();

            Assert.Null(result);
        }
    }
}