using System.Globalization;
using System.Text.RegularExpressions;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string
{
    public class when_call_FirstCharToUpper : Context
    {
        private char _expectedChar;

        public when_call_FirstCharToUpper()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            var regex = new Regex("^\\d+");

            _str = regex.Replace(_str, string.Empty).ToLower();
            _expectedChar = char.ToUpper(_str[0], CultureInfo.InvariantCulture);
        }

        [Fact]
        public void then_returns_string_with_the_first_capital_letter()
        {
            var result = _str.FirstCharToUpper();

            Assert.Equal(_expectedChar, result[0]);
        }
    }
}