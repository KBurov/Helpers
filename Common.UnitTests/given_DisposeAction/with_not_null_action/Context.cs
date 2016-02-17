using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_DisposeAction.with_not_null_action
{
    public abstract class Context : ContextBase
    {
        protected DisposeAction _disposeAction;
        protected bool _actionCalled;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _actionCalled = false;
            _disposeAction = new DisposeAction(() => _actionCalled = true);
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            _disposeAction = null;
            _actionCalled = false;
        }
    }
}