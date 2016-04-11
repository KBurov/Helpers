using Helpers.Common.Extensions;

using Xunit;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable.with_not_empty_sources.with_not_null_comparer
{
    public sealed class when_call_MergeSortedEnumerable : Context
    {
        [Fact]
        public void then_ordered_result_returns()
        {
            var result = _sources.MergeSortedEnumerable(_comparer);

            Assert.NotNull(result);

            var isFirst = true;
            var previous = 0;

            foreach (var item in result) {
                if (!isFirst) {
                    Assert.True(previous <= item);
                }
                else {
                    isFirst = false;
                }

                previous = item;
            }
        }
    }
}