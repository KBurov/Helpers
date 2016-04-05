using System;
using System.Threading;

using Helpers.Common.Extensions.Threading;

using Xunit;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_null_locker
{
    public class when_call_GetReadLock
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => ((ReaderWriterLockSlim) null).GetReadLock());
        }
    }
}