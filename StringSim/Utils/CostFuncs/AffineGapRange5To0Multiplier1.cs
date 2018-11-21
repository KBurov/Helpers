using System;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.CostFuncs
{
    /// <summary>
    /// Implements a Affine Gap cost function.
    /// </summary>
    [Serializable]
    public sealed class AffineGapRange5To0Multiplier1 : AbstractAffineGapCost
    {
        private const int CharExactMatchScore = 5;
        private const int CharMismatchMatchScore = 0;

        /// <inheritdoc />
        public override double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap)
        {
            return stringIndexStartGap >= stringIndexEndGap
                ? CharMismatchMatchScore
                : CharExactMatchScore + (stringIndexEndGap - 1 - stringIndexStartGap);
        }

        /// <inheritdoc />
        public override double MaxCost => CharExactMatchScore;

        /// <inheritdoc />
        public override double MinCost => CharMismatchMatchScore;

        /// <inheritdoc />
        public override string ShortDescriptionString => "AffineGapRange5To0Multiplier1";
    }
}