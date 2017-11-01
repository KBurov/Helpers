using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string.with_empty_EmptyValues
{
    public sealed class when_call_IsEmpty : Context
    {
        public when_call_IsEmpty()
        {
            SetUp();
        }

        [Fact]
        public void then_returns_false()
        {
            var result = _str.IsEmpty();

            Assert.False(result);
        }
    }
}