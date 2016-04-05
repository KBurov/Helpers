using System.Threading;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetWriteLock
{
    public sealed class when_call_TryEnterReadLock : Context
    {
        [Fact]
        public void then_throws_exception()
        {
            using (_locker.GetWriteLock()) {
                Assert.Throws<LockRecursionException>(() => _locker.TryEnterReadLock(0));
            }
        }
    }
}