using System;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_null_locker
{
    public sealed class when_call_GetUpgradeableReadLock : Context
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => _locker.GetUpgradeableReadLock());
        }
    }
}