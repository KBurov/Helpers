using System.Text;

namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Interface for stop word handlers.
    /// </summary>
    public interface ITermHandler
    {
        /// <summary>
        /// Adds a Word to the interface.
        /// </summary>
        /// <param name="termToAdd">termToAdd the Word to add</param>
        void AddWord(string termToAdd);

        /// <summary>
        /// Determines if a given term is a word or not.
        /// </summary>
        /// <param name="termToTest">termToTest the term to test</param>
        /// <returns>true if a stopword, false otherwise.</returns>
        bool IsWord(string termToTest);

        /// <summary>
        /// Removes the given word from the list.
        /// </summary>
        /// <param name="termToRemove">termToRemove the word term to remove</param>
        void RemoveWord(string termToRemove);

        /// <summary>
        /// Gets the number of stopwords in the list.
        /// </summary>
        int NumberOfWords { get; }

        /// <summary>
        /// Gets the short description string of the stop word handler used.
        /// </summary>
        string ShortDescriptionString { get; }

        /// <summary>
        /// Gets the words as an output string buffer.
        /// </summary>
        StringBuilder WordsAsBuffer { get; }
    }
}