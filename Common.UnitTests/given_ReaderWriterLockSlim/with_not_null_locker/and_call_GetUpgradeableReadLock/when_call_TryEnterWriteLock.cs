using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetUpgradeableReadLock
{
    public sealed class when_call_TryEnterWriteLock : Context
    {
        [Fact]
        public void then_call_successful()
        {
            bool result;

            using (_locker.GetUpgradeableReadLock()) {
                result = _locker.TryEnterReadLock(0);

                if (result) {
                    _locker.ExitReadLock();
                }
            }

            Assert.True(result);
        }
    }
}