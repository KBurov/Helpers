﻿using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_empty_string
{
    public class when_call_IsInt : Context
    {
        [Fact]
        public void then_returns_false()
        {
            var result = _str.IsInt();

            Assert.False(result);
        }
    }
}