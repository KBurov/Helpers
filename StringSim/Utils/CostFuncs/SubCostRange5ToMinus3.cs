using System;
using System.Collections.Generic;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.CostFuncs
{
    /// <summary>
    /// Implements a cost function as used in Monge Elkan where by an exact match
    /// no match or an approximate match whereby a set of characters are in an approximate range.
    /// For pairings in {dt} {gj} {lr} {mn} {bpv} {aeiou} {,.}
    /// </summary>
    [Serializable]
    public sealed class SubCostRange5ToMinus3 : AbstractSubstitutionCost
    {
        private const int CharApproximateMatchScore = 3;
        private const int CharExactMatchScore = 5;
        private const int CharMismatchMatchScore = -3;

        /// <summary>
        /// Approximate character set.
        /// </summary>
        private readonly IList<IList<string>> _approx;

        /// <summary>
        /// Default constructor.
        /// Sets up the matching sets
        /// approximate match = +3,
        /// for pairings in {dt} {gj} {lr} {mn} {bpv} {aeiou} {,.}.
        /// </summary>
        public SubCostRange5ToMinus3()
        {
            _approx = new List<IList<string>>
                {
                    [0] = new List<string> {"d", "t"},
                    [1] = new List<string> {"g", "j"},
                    [2] = new List<string> {"l", "r"},
                    [3] = new List<string> {"m", "n"},
                    [4] = new List<string> {"b", "p", "v"},
                    [5] = new List<string> {"a", "e", "i", "o", "u"},
                    [6] = new List<string> {",", "."}
                };
        }

        /// <inheritdoc />
        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if (firstWord != null && secondWord != null) {
                if (firstWord.Length <= firstWordIndex || firstWordIndex < 0)
                    return CharMismatchMatchScore;

                if (secondWord.Length <= secondWordIndex || secondWordIndex < 0)
                    return CharMismatchMatchScore;

                if (firstWord[firstWordIndex] == secondWord[secondWordIndex])
                    return CharExactMatchScore;

                var si = firstWord[firstWordIndex].ToString().ToLowerInvariant();
                var ti = secondWord[secondWordIndex].ToString().ToLowerInvariant();

                for (var i = 0;i < _approx.Count;i++)
                    if (_approx[i].Contains(si) && _approx[i].Contains(ti))
                        return CharApproximateMatchScore;
            }

            return CharMismatchMatchScore;
        }

        /// <inheritdoc />
        public override double MaxCost => CharExactMatchScore;

        /// <inheritdoc />
        public override double MinCost => CharMismatchMatchScore;

        /// <inheritdoc />
        public override string ShortDescriptionString => "SubCostRange5ToMinus3";
    }
}