﻿using System;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker.and_call_GetReadLock
{
    public sealed class when_call_TryEnterUpgradeableReadLock_from_another_thread : Context
    {
        [Fact]
        public void then_call_successful()
        {
            Func<bool> a = () =>
                {
                    var result = _locker.TryEnterUpgradeableReadLock(0);
                    if (result) _locker.ExitUpgradeableReadLock();
                    return result;
                };

            using (_locker.GetReadLock()) {
                Assert.True(a.EndInvoke(a.BeginInvoke(null, null)));
            }
        }
    }
}