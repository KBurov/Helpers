﻿using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_empty_string
{
    public class when_call_ParseDouble : Context
    {
        [Fact]
        public void then_returns_null()
        {
            var result = _str.ParseDouble();

            Assert.Null(result);
        }
    }
}