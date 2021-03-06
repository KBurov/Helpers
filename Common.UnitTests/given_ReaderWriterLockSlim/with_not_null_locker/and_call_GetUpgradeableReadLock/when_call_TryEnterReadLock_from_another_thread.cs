﻿using System;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetUpgradeableReadLock
{
    public sealed class when_call_TryEnterReadLock_from_another_thread : Context
    {
        [Fact]
        public void then_call_successful()
        {
            Func<bool> a = () =>
                {
                    var result = _locker.TryEnterReadLock(0);
                    if (result) _locker.ExitReadLock();
                    return result;
                };

            using (_locker.GetUpgradeableReadLock()) {
                Assert.True(a.EndInvoke(a.BeginInvoke(null, null)));
            }
        }
    }
}