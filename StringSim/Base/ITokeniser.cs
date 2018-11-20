using System.Collections.ObjectModel;

namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Interface for a Tokeniser class.
    /// </summary>
    public interface ITokeniser
    {
        /// <summary>
        /// Return tokenized version of a string.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>tokenized version of a string</returns>
        Collection<string> Tokenize(string word);

        /// <summary>
        /// Return tokenized version of a string as a set.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>tokenized version of a string as a set</returns>
        Collection<string> TokenizeToSet(string word);

        /// <summary>
        /// Gets the delimitors used - (if applicable).
        /// </summary>
        string Delimiters { get; }

        /// <summary>
        /// Gets the tokenisation method.
        /// </summary>
        string ShortDescriptionString { get; }

        /// <summary>
        /// Gets the stop word handler used.
        /// </summary>
        ITermHandler StopWordHandler { get; set; }
    }
}