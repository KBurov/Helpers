using System;

namespace Helpers.TestFramework
{
    /// <summary>
    /// Base class for either unit or integration tests context classes.
    /// </summary>
    public abstract class ContextBase : IDisposable
    {
        private bool _disposed;

        #region IDisposable implementation
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resource.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed) {
                if (disposing)
                    Cleanup();

                _disposed = true;
            }
        }
        #endregion

        /// <summary>
        /// Parameterless constructor to support test setup logic.
        /// </summary>
        protected ContextBase()
        {
            _disposed = false;
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~ContextBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Implement in derived classes for test setup logic.
        /// Should be called from parameterless constructor.
        /// </summary>
        protected virtual void SetUp() {}

        /// <summary>
        /// Implement in derived classes for test cleanup logic.
        /// </summary>
        protected virtual void Cleanup() {}
    }
}