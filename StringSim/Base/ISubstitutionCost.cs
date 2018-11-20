namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Interface for a cost function d(i,j).
    /// </summary>
    public interface ISubstitutionCost
    {
        /// <summary>
        /// Get cost between characters.
        /// </summary>
        /// <param name="firstWord">the firstWord to evaluate the cost</param>
        /// <param name="firstWordIndex">the index within the firstWord to test</param>
        /// <param name="secondWord">the secondWord to evaluate the cost</param>
        /// <param name="secondWordIndex">the index within the secondWord to test</param>
        /// <returns>a cost between characters</returns>
        double GetCost(string firstWord, int firstWordIndex, string secondWord, int secondWordIndex);

        /// <summary>
        /// Returns the maximum possible cost.
        /// </summary>
        double MaxCost { get; }

        /// <summary>
        /// Returns the minimum possible cost.
        /// </summary>
        double MinCost { get; }

        /// <summary>
        /// Returns the name of the cost function.
        /// </summary>
        string ShortDescriptionString { get; }
    }
}