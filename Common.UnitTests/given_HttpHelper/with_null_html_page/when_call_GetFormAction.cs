using System;
using System.Linq;

using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_null_html_page
{
    public sealed class when_call_GetFormAction : HttpHelperContextBase
    {
        public when_call_GetFormAction()
        {
            SetUp();
        }

        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentException>(() => _httpHelper.GetFormAction(string.Empty).ToList());
        }
    }
}