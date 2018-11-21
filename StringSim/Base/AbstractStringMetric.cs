using System;

namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Class which all metrics inherit from.
    /// </summary>
    /// <remarks>
    /// This class implemented a few basic methods and then leaves the others to be implemented by the similarity
    /// metric itself.
    /// </remarks>
    [Serializable]
    public abstract class AbstractStringMetric : IStringMetric
    {
        #region IStringMetric implementation
        /// <inheritdoc />
        public abstract double GetSimilarity(string firstWord, string secondWord);

        /// <inheritdoc />
        public abstract string GetSimilarityExplained(string firstWord, string secondWord);

        /// <inheritdoc />
        public long GetSimilarityTimingActual(string firstWord, string secondWord)
        {
            var timeBefore = (DateTime.Now.Ticks - 621355968000000000L) / 10000L;

            GetSimilarity(firstWord, secondWord);

            var timeAfter = (DateTime.Now.Ticks - 621355968000000000L) / 10000L;

            return timeAfter - timeBefore;
        }

        /// <inheritdoc />
        public abstract double GetSimilarityTimingEstimated(string firstWord, string secondWord);

        /// <inheritdoc />
        public abstract double GetUnnormalisedSimilarity(string firstWord, string secondWord);

        /// <inheritdoc />
        public abstract string LongDescriptionString { get; }

        /// <inheritdoc />
        public abstract string ShortDescriptionString { get; }
        #endregion

        /// <summary>
        /// Does a batch comparison of the set of strings with the given
        /// comparator string returning an array of results equal in length
        /// to the size of the given set of strings to test.
        /// </summary>
        /// <param name="setRenamed">an array of strings to test against the comparator string</param>
        /// <param name="comparator">the comparator string to test the array against</param>
        /// <returns>an array of results equal in length to the size of the given set of strings to test</returns>
        public double[] BatchCompareSet(string[] setRenamed, string comparator)
        {
            if (setRenamed != null && comparator != null) {
                var results = new double[setRenamed.Length];

                for (var strNum = 0;strNum < setRenamed.Length;strNum++)
                    results[strNum] = GetSimilarity(setRenamed[strNum], comparator);

                return results;
            }

            return null;
        }

        /// <summary>
        /// Does a batch comparison of one set of strings against another set
        /// of strings returning an array of results equal in length
        /// to the minimum size of the given sets of strings to test.
        /// </summary>
        /// <param name="firstSet">an array of strings to test</param>
        /// <param name="secondSet">an array of strings to test the first array against</param>
        /// <returns>an array of results equal in length to the minimum size of the given sets of strings to test</returns>
        public double[] BatchCompareSets(string[] firstSet, string[] secondSet)
        {
            if (firstSet != null && secondSet != null) {
                var results = firstSet.Length <= secondSet.Length ? new double[firstSet.Length] : new double[secondSet.Length];

                for (var strNum = 0;strNum < results.Length;strNum++)
                    results[strNum] = GetSimilarity(firstSet[strNum], secondSet[strNum]);

                return results;
            }

            return null;
        }
    }
}