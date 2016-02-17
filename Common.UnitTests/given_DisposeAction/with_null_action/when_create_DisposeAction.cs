using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_DisposeAction.with_null_action
{
    public class when_create_DisposeAction
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new DisposeAction(null));
        }
    }
}