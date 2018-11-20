namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Interface for AffineGapCost functions to be interchanged.
    /// </summary>
    public interface IAffineGapCost
    {
        /// <summary>
        /// Get cost between characters.
        /// </summary>
        /// <param name="textToGap">the string to get the cost of a gap</param>
        /// <param name="stringIndexStartGap">the index within the string to test a start gap from</param>
        /// <param name="stringIndexEndGap">the index within the string to test a end gap to</param>
        /// <returns>returns cost between characters</returns>
        double GetCost(string textToGap, int stringIndexStartGap, int stringIndexEndGap);

        /// <summary>
        /// Returns the maximum possible cost.
        /// </summary>
        double MaxCost { get; }

        /// <summary>
        /// Returns the minimum possible cost.
        /// </summary>
        double MinCost { get; }

        /// <summary>
        /// Returns the name of the affine gap cost function.
        /// </summary>
        string ShortDescriptionString { get; }
    }
}