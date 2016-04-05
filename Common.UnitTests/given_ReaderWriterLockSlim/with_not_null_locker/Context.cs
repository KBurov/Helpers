using System.Threading;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim.with_not_null_locker
{
    public abstract class Context : ContextBase
    {
        protected ReaderWriterLockSlim _locker;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _locker = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            _locker.Dispose();
        }
    }
}