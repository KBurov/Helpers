using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_null_string
{
    public class when_call_IsEmpty : with_empty_string.Context
    {
        [Fact]
        public void then_returns_true()
        {
            var result = _str.IsEmpty();

            Assert.True(result);
        }
    }
}