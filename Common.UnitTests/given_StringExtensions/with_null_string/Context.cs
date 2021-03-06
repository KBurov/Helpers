﻿using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_StringExtensions.with_null_string
{
    public abstract class Context : ContextBase
    {
        protected string _str;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _str = null;
        }
    }
}