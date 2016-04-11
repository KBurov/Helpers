using System;
using System.Collections.Generic;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_null_sources
{
    public class when_call_MergeSortedEnumerable
    {
        [Fact]
        public void then_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => ((IEnumerable<int>[]) null).MergeSortedEnumerable(new TestComparer()));
        }
    }
}