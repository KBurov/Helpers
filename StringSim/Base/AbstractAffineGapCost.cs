using System;

namespace Helpers.StringSim.Base
{
    /// <summary>
    ///  Class used as a base for all affine gap classes.
    /// </summary>
    [Serializable]
    public abstract class AbstractAffineGapCost : IAffineGapCost
    {
        /// <inheritdoc />
        public abstract double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap);

        /// <inheritdoc />
        public abstract double MaxCost { get; }

        /// <inheritdoc />
        public abstract double MinCost { get; }

        /// <inheritdoc />
        public abstract string ShortDescriptionString { get; }
    }
}