using System.Threading;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetReadLock
{
    public sealed class when_call_TryEnterUpgradeableReadLock : Context
    {
        [Fact]
        public void then_throws_exception()
        {
            using (_locker.GetReadLock()) {
                Assert.Throws<LockRecursionException>(() => _locker.TryEnterUpgradeableReadLock(0));
            }
        }
    }
}