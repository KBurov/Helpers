using System;
using System.Diagnostics.Contracts;

namespace Helpers.Common
{
    /// <summary>
    /// Helps to call an action automatically on call <see cref="IDisposable.Dispose" />.
    /// </summary>
    public sealed class DisposeAction : IDisposable
    {
        private readonly Action _disposeAction;
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
            Contract.Ensures(_disposed);

            if (!_disposed) {
                if (disposing) {
                    _disposeAction();
                }

                _disposed = true;
            }
        }
        #endregion

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="disposeAction">action that should be called</param>
        /// <exception cref="ArgumentNullException"><paramref name="disposeAction" /> is null</exception>
        public DisposeAction(Action disposeAction)
        {
            Contract.Requires<ArgumentNullException>(disposeAction != null, "disposeAction cannot be null");
            Contract.Ensures(_disposeAction != null);

            _disposeAction = disposeAction;
            _disposed = false;
        }

        /// <summary>
        /// Finalizer.
        /// </summary>
        ~DisposeAction()
        {
            Dispose(false);
        }
    }
}