using System.Collections.Generic;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_empty_sources
{
    public abstract class Context : ContextBase
    {
        protected IEnumerable<int>[] _sources;
        protected IComparer<int> _comparer;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _sources = new IEnumerable<int>[0];
            _comparer = new TestComparer();
        }
    }
}