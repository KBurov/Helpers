using System;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.CostFuncs
{
    /// <summary>
    /// Implements a Affine Gap cost function.
    /// </summary>
    [Serializable]
    public sealed class AffineGapRange1To0Multiplier1Over3 : AbstractAffineGapCost
    {
        private const int CharExactMatchScore = 1;
        private const int CharMismatchMatchScore = 0;

        /// <inheritdoc />
        public override double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap)
        {
            return stringIndexStartGap >= stringIndexEndGap
                ? CharMismatchMatchScore
                : CharExactMatchScore + (stringIndexEndGap - 1 - stringIndexStartGap) * 0.3333333F;
        }

        /// <inheritdoc />
        public override double MaxCost => 1D;

        /// <inheritdoc />
        public override double MinCost => 0D;

        /// <inheritdoc />
        public override string ShortDescriptionString => "AffineGapRange1To0Multiplier1Over3";
    }
}