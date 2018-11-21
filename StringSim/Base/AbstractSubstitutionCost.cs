using System;

namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Class for substiution costs.
    /// </summary>
    [Serializable]
    public abstract class AbstractSubstitutionCost : ISubstitutionCost
    {
        /// <inheritdoc />
        public abstract double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex);

        /// <inheritdoc />
        public abstract double MaxCost { get; }

        /// <inheritdoc />
        public abstract double MinCost { get; }

        /// <inheritdoc />
        public abstract string ShortDescriptionString { get; }
    }
}