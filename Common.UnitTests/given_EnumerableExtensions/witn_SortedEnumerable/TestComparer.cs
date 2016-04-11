using System.Collections.Generic;

namespace Helpers.Common.UnitTests.given_EnumerableExtensions.witn_SortedEnumerable
{
    internal sealed class TestComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x < y ? -1 : x == y ? 0 : 1;
        }
    }
}