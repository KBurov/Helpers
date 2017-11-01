using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string.with_filled_EmptyValues.with_string_not_from_EmptyValues
{
    public sealed class when_call_IsEmpty : ContextWithEmptyValues
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