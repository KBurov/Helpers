using System;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.CostFuncs
{
    /// <summary>
    /// Implements a substitution cost function where d(i,j) = 1 if i does not equal j, -2 if i equals j.
    /// </summary>
    [Serializable]
    public sealed class SubCostRange1ToMinus2 : AbstractSubstitutionCost
    {
        private const int CharExactMatchScore = 1;
        private const int CharMismatchMatchScore = -2;

        /// <inheritdoc />
        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            if (firstWord != null && secondWord != null) {
                if (firstWord.Length <= firstWordIndex || firstWordIndex < 0)
                    return CharMismatchMatchScore;

                return secondWord.Length <= secondWordIndex || secondWordIndex < 0
                    ? CharMismatchMatchScore
                    : (firstWord[firstWordIndex] != secondWord[secondWordIndex] ? CharMismatchMatchScore : CharExactMatchScore);
            }

            return CharMismatchMatchScore;
        }

        /// <inheritdoc />
        public override double MaxCost => CharExactMatchScore;

        /// <inheritdoc />
        public override double MinCost => CharMismatchMatchScore;

        /// <inheritdoc />
        public override string ShortDescriptionString => "SubCostRange1ToMinus2";
    }
}