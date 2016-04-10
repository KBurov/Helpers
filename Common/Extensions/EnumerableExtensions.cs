using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Helpers.Common.Extensions
{
    /// <summary>
    /// Extension and helper methods to deal with <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Merge sorted enumerable sources.
        /// </summary>
        /// <typeparam name="T">type of enumerable elements</typeparam>
        /// <param name="sources">collection of sorted enumerables</param>
        /// <param name="comparer">enumerable elemenets comparer (<see cref="IComparer{T}"/></param>
        /// <returns>object with <see cref="IEnumerator{T}"/> interface</returns>
        public static IEnumerable<T> MergeSortedEnumerable<T>(IEnumerable<T>[] sources, IComparer<T> comparer)
        {
            Contract.Requires<ArgumentNullException>(sources != null, "sources cannot be null");
            Contract.Requires<ArgumentNullException>(comparer != null, "comparer cannot be null");
            Contract.Ensures(Contract.Result<IEnumerable<T>>() != null);

            switch (sources.Length) {
                case 0:
                    return Enumerable.Empty<T>();
                case 1:
                    return sources[0];
                default:
                    return InternalMergeSortedEnumerable(sources, comparer);
            }
        }

        private static IEnumerable<T> InternalMergeSortedEnumerable<T>(IEnumerable<IEnumerable<T>> sources, IComparer<T> comparer)
        {
            var enumerators = sources
                .Select(list => list.GetEnumerator())
                .Where(enumerator => enumerator.MoveNext())
                .ToArray();

            Array.Sort(enumerators, (enumerator1, enumerator2) => comparer.Compare(enumerator1.Current, enumerator2.Current));

            while (enumerators.Length > 0) {
                yield return enumerators[0].Current;

                if (!enumerators[0].MoveNext()) {
                    enumerators = enumerators
                        .Skip(1)
                        .ToArray();
                }

                if (enumerators.Length > 1) {
                    for (var i = 0;i < enumerators.Length - 1;++i) {
                        if (comparer.Compare(enumerators[i].Current, enumerators[i + 1].Current) > 0) {
                            var temp = enumerators[i + 1];
                            enumerators[i + 1] = enumerators[i];
                            enumerators[i] = temp;
                        }
                        else {
                            break;
                        }
                    }
                }
            }
        }
    }
}