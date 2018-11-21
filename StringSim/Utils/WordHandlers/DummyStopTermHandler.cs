using System.Text;

using Helpers.StringSim.Base;

namespace Helpers.StringSim.Utils.WordHandlers
{
    /// <summary>
    /// Implements a dummy stop word handling function whereby no stopwords are considered.
    /// </summary>
    public sealed class DummyStopTermHandler : ITermHandler
    {
        #region ITermHandler implementation
        /// <inheritdoc />
        public void AddWord(string termToAdd) {}

        /// <inheritdoc />
        public bool IsWord(string termToTest) => false;

        /// <inheritdoc />
        public void RemoveWord(string termToRemove) {}

        /// <inheritdoc />
        public int NumberOfWords => 0;

        /// <inheritdoc />
        public string ShortDescriptionString => "DummyStopTermHandler";

        /// <inheritdoc />
        public StringBuilder WordsAsBuffer => new StringBuilder();
        #endregion
    }
}