using System;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_Retry.with_not_null_func
{
    public abstract class Context : ContextBase
    {
        protected Func<int> _simpleFunc;
        protected Func<int> _funcWithException;
        protected bool _funcCalled;
        protected uint _numberOfCalls;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _funcCalled = false;
            _numberOfCalls = 0u;
            _simpleFunc = () =>
                {
                    _funcCalled = true;

                    return 1;
                };
            _funcWithException = () =>
                {
                    _numberOfCalls++;

                    _funcCalled = true;

                    throw new Exception();
                };
        }

        protected override void Cleanup()
        {
            base.Cleanup();

            _funcWithException = null;
            _simpleFunc = null;
            _numberOfCalls = 0u;
            _funcCalled = false;
        }
    }
}