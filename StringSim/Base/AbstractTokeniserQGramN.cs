using System;
using System.Collections.ObjectModel;
using System.Text;

using Helpers.StringSim.Utils.Tokenisers;

namespace Helpers.StringSim.Base
{
    /// <summary>
    /// Implements a QGram Tokeniser to cope with all gram sizes.
    /// </summary>
    /// <remarks>
    /// The CCI value determines at what level the skip characters
    /// are gathered. This is a variation of the normal QGram analysis when
    /// character pairs are created having skipped characters in the words.
    /// </remarks>
    [Serializable]
    public abstract class AbstractTokeniserQGramN : ITokeniser
    {
        private const string DefaultEndPadCharacter = "#";
        private const string DefaultStartPadCharacter = "?";

        /// <summary>
        /// CCI - error level used for the sgram analysis.
        /// </summary>
        /// <description>a value of 1 means the sgram will skip a letter when generating the tokens</description>
        public int CharacterCombinationIndex { get; set; }

        /// <summary>
        /// Length of the qgram tokens to create.
        /// </summary>
        public int QGramLength { get; set; }

        /// <summary>
        /// Supplied word.
        /// </summary>
        public string SuppliedWord { get; set; }

        /// <summary>
        /// Contains token utilities
        /// </summary>
        public TokeniserUtilities<string> TokenUtilities { get; set; }

        #region ITokeniser implementation
        /// <inheritdoc />
        public abstract Collection<string> Tokenize(string word);

        /// <inheritdoc />
        public Collection<string> TokenizeToSet(string word)
        {
            if (!string.IsNullOrEmpty(word)) {
                SuppliedWord = word;
                return TokenUtilities.CreateSet(Tokenize(word));
            }

            return null;
        }

        /// <inheritdoc />
        public string Delimiters => string.Empty;

        /// <inheritdoc />
        public abstract string ShortDescriptionString { get; }

        /// <inheritdoc />
        public ITermHandler StopWordHandler { get; set; }
        #endregion

        /// <summary>
        /// full version of Tokenise which allows for different token lengths
        /// as well as the characterCombinationIndexValue error level as well.
        /// </summary>
        /// <param name="word">word to tokenise</param>
        /// <param name="extended">whether to generate extended tokens</param>
        /// <param name="tokenLength">length of tokens</param>
        /// <param name="characterCombinationIndexValue">error level for skip tokens</param>
        /// <returns>collection of tokens</returns>
        public Collection<string> Tokenize(string word, bool extended, int tokenLength, int characterCombinationIndexValue)
        {
            if (!string.IsNullOrEmpty(word)) {
                SuppliedWord = word;

                var anArray = new Collection<string>();
                var wordLength = word.Length;
                var maxValue = 0;

                if (tokenLength > 0)
                    maxValue = tokenLength - 1;

                var testword = new StringBuilder(wordLength + 2 * maxValue);

                if (extended)
                    testword.Insert(0, DefaultStartPadCharacter, maxValue);

                testword.Append(word);

                if (extended)
                    testword.Insert(testword.Length, DefaultEndPadCharacter, maxValue);
                // normal n-gram keys characterCombinationIndex = 0
                var testWordOne = testword.ToString();
                int maxLoop;

                if (extended)
                    maxLoop = wordLength + maxValue;
                else
                    maxLoop = wordLength - tokenLength + 1;

                for (var i = 0;i < maxLoop;i++) {
                    var testWord = testWordOne.Substring(i, tokenLength);

                    if (!StopWordHandler.IsWord(testWord))
                        anArray.Add(testWord);
                }

                if (characterCombinationIndexValue != 0) {
                    // special characterCombinationIndex n-gram keys
                    testWordOne = testword.ToString();
                    maxLoop -= 1; // have to reduce by 1 as we are skipping a letter

                    for (var i = 0;i < maxLoop;i++) {
                        var testWord = testWordOne.Substring(i, maxValue) + testWordOne.Substring(i + tokenLength, 1);

                        if (!StopWordHandler.IsWord(testWord) && !anArray.Contains(testWord))
                            anArray.Add(testWord);
                    }
                }

                return anArray;
            }

            return null;
        }
    }
}