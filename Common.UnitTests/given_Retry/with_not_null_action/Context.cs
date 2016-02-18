using System;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_action
{
    public abstract class Context : ContextBase
    {
        protected Action _simpleAction;
        protected Action _actionWithException;
        protected bool _actionCalled;
        protected uint _numberOfCalls;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _actionCalled = false;
            _numberOfCalls = 0u;
            _simpleAction = () => _actionCalled = true;
            _actionWithException = () =>
                {
                    _numberOfCalls++;

                    _actionCalled = true;

                    throw new Exception();
                };
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            _actionWithException = null;
            _simpleAction = null;
            _numberOfCalls = 0u;
            _actionCalled = false;
        }
    }
}