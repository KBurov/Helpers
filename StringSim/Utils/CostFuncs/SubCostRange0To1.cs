using System;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.CostFuncs
{
    /// <summary>
    /// Implements a substitution cost function where d(i,j) = 1 if i does not equal j, 0 if i equals j.
    /// </summary>
    [Serializable]
    public sealed class SubCostRange0To1 : AbstractSubstitutionCost
    {
        private const int CharExactMatchScore = 1;
        private const int CharMismatchMatchScore = 0;

        /// <inheritdoc />
        public override double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex)
        {
            return firstWord != null && secondWord != null
                ? (firstWord[firstWordIndex] != secondWord[secondWordIndex] ? CharExactMatchScore : CharMismatchMatchScore)
                : 0D;
        }

        /// <inheritdoc />
        public override double MaxCost => CharExactMatchScore;

        /// <inheritdoc />
        public override double MinCost => CharMismatchMatchScore;

        /// <inheritdoc />
        public override string ShortDescriptionString => "SubCostRange0To1";
    }
}