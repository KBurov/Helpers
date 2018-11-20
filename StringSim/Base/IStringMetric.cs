namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Interface for the string metrics.
    /// </summary>
    public interface IStringMetric
    {
        /// <summary>
        /// Returns a similarity measure of the string comparison.
        /// </summary>
        /// <param name="firstWord">string 1</param>
        /// <param name="secondWord">string 2</param>
        /// <returns>a double between zero to one (zero = no similarity, one = matching strings)</returns>
        double GetSimilarity(string firstWord, string secondWord);

        /// <summary>
        /// Gets a div class xhtml similarity explaining the operation of the metric.
        /// </summary>
        /// <param name="firstWord">string 1</param>
        /// <param name="secondWord">string 2</param>
        /// <returns>a div class html section detailing the metric operation</returns>
        string GetSimilarityExplained(string firstWord, string secondWord);

        /// <summary>
        /// Gets the actual time in milliseconds it takes to perform a similarity timing.
        /// </summary>
        /// <param name="firstWord">string 1</param>
        /// <param name="secondWord">string 2</param>
        /// <returns>the actual time in milliseconds taken to perform the similarity measure</returns>
        /// <remarks>This call takes as long as the similarity metric to perform so should not be done in normal cercumstances.</remarks>
        long GetSimilarityTimingActual(string firstWord, string secondWord);

        /// <summary>
        /// Gets the estimated time in milliseconds it takes to perform a similarity timing.
        /// </summary>
        /// <param name="firstWord">string 1</param>
        /// <param name="secondWord">string 2</param>
        /// <returns>an estimated time in milliseconds taken to perform the similarity measure</returns>
        double GetSimilarityTimingEstimated(string firstWord, string secondWord);

        /// <summary> 
        /// Gets the un-normalised similarity measure of the metric for the given strings.
        /// </summary>
        /// <param name="firstWord">string 1</param>
        /// <param name="secondWord">string 2</param>
        /// <returns>a score of the similarity measure (un-normalised)</returns>
        double GetUnnormalisedSimilarity(string firstWord, string secondWord);

        /// <summary>
        /// Returns a long string of the string metric description.
        /// </summary>
        string LongDescriptionString { get; }

        /// <summary>
        /// Returns a string of the string metric name.
        /// </summary>
        string ShortDescriptionString { get; }
    }
}