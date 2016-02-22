﻿using System.Linq;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_not_empty_string
{
    public class when_call_Reverse : Context
    {
        private string _expectedValue;

        public when_call_Reverse()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _expectedValue = new string(Enumerable.Reverse(_sut).ToArray());
        }

        [Fact]
        public void then_returns_with_reverted_value()
        {
            var result = _sut.Reverse();

            Assert.Equal(_expectedValue, result);
        }
    }
}