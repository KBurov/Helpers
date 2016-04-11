using System;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_not_empty_sources.with_null_comparer
{
    public sealed class when_call_MergeSortedEnumerable : Context
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => _sources.MergeSortedEnumerable(null));
        }
    }
}