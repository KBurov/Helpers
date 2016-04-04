using System.Threading;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_ReaderWriterLockSlim
{
    public abstract class Context : ContextBase
    {
        protected ReaderWriterLockSlim _locker = null;
    }
}