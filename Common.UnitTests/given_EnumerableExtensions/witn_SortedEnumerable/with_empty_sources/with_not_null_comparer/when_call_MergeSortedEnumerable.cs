using System.Linq;

using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_empty_sources.with_not_null_comparer
{
    public sealed class when_call_MergeSortedEnumerable : Context
    {
        [Fact]
        public void then_empty_result_returns()
        {
            var result = _sources.MergeSortedEnumerable(_comparer);

            Assert.NotNull(result);
            Assert.True(!result.Any());
        }
    }
}