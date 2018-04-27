using System.Collections.Generic;
using System.Linq;

using AutoFixture;

using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_not_empty_sources
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

            var fixture = new Fixture();

            _sources = fixture.CreateMany<IEnumerable<int>>().ToArray();
            _comparer = new TestComparer();

            for (var i = 0; i < _sources.Length; i++) {
                _sources[i] = fixture.CreateMany<int>().OrderBy(item => item);
            }
        }
    }
}