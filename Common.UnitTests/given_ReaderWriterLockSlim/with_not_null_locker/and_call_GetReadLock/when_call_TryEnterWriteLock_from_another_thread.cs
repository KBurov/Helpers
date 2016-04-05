using System;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetReadLock
{
    public sealed class when_call_TryEnterWriteLock_from_another_thread : Context
    {
        [Fact]
        public void then_call_failed()
        {
            Func<bool> a = () =>
                {
                    var result = _locker.TryEnterWriteLock(0);
                    if (result) _locker.ExitWriteLock();
                    return result;
                };

            using (_locker.GetReadLock()) {
                Assert.False(a.EndInvoke(a.BeginInvoke(null, null)));
            }
        }
    }
}