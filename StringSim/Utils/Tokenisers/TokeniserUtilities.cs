using System;
using System.Collections.Generic;

namespace Helpers.StringSim.Utils.Tokenisers
{
    /// <summary>
    /// Contains utility functions for the tokenisers to use.
    /// These are in two main version collections or sets.
    /// Collection can contain the same value multiple times ad set can only have the value once.
    /// </summary>
    /// <typeparam name="T">type for token collection</typeparam>
    [Serializable]
    public class TokeniserUtilities<T>
    {
        /// <summary>
        /// Token count from first token list.
        /// </summary>
        public int FirstSetTokenCount { get; private set; }

        /// <summary>
        /// Token count from first token list.
        /// </summary>
        public int FirstTokenCount { get; private set; }

        /// <summary>
        /// Merged token List (unique tokens only).
        /// </summary>
        public IList<T> MergedTokens { get; }

        /// <summary>
        /// Token count from second token list.
        /// </summary>
        public int SecondSetTokenCount { get; private set; }

        /// <summary>
        /// Token count from second token list.
        /// </summary>
        public int SecondTokenCount { get; private set; }

        /// <summary>
        /// Merged token List (unique tokens only).
        /// </summary>
        public ISet<T> TokenSet { get; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TokeniserUtilities()
        {
            MergedTokens = new List<T>();
            TokenSet = new HashSet<T>();
        }

        /// <summary>
        /// Returns the number of common tokens from the two supplied token sets.
        /// </summary>
        /// <returns>the number of common tokens from the two supplied token sets</returns>
        public int CommonSetTerms()
        {
            return FirstSetTokenCount + SecondSetTokenCount - TokenSet.Count;
        }

        /// <summary>
        /// Returns the number of common tokens from the two supplied token collections.
        /// </summary>
        /// <returns>the number of common tokens from the two supplied token collections</returns>
        public int CommonTerms()
        {
            return FirstTokenCount + SecondTokenCount - MergedTokens.Count;
        }

        /// <summary>
        /// Merge two token lists to keep all tokens.
        /// </summary>
        /// <param name="firstTokens">first token list</param>
        /// <param name="secondTokens">second token list</param>
        /// <returns>list of all tokens</returns>
        public IList<T> CreateMergedList(IEnumerable<T> firstTokens, IEnumerable<T> secondTokens)
        {
            MergedTokens.Clear();

            MergeLists(firstTokens);

            FirstTokenCount = MergedTokens.Count;

            MergeLists(secondTokens);

            SecondTokenCount = MergedTokens.Count - FirstSetTokenCount;

            return MergedTokens;
        }

        /// <summary>
        /// Merge two token lists to keep only unique tokens.
        /// </summary>
        /// <param name="firstTokens">first token list</param>
        /// <param name="secondTokens">second token list</param>
        /// <returns>list of unique tokens</returns>
        public ISet<T> CreateMergedSet(IEnumerable<T> firstTokens, IEnumerable<T> secondTokens)
        {
            TokenSet.Clear();

            MergeIntoSet(firstTokens);

            FirstSetTokenCount = TokenSet.Count;

            MergeIntoSet(secondTokens);

            SecondSetTokenCount = TokenSet.Count - FirstSetTokenCount;

            return TokenSet;
        }

        /// <summary>
        /// Create a single token list of unique tokens.
        /// </summary>
        /// <param name="tokenList">token list to use</param>
        /// <returns>unique token list - sorted</returns>
        public ISet<T> CreateSet(IEnumerable<T> tokenList)
        {
            TokenSet.Clear();

            AddUniqueTokens(tokenList);

            FirstTokenCount = TokenSet.Count;
            SecondTokenCount = 0;

            return TokenSet;
        }

        /// <summary>
        /// Merging extra token lists into the set.
        /// </summary>
        /// <param name="firstTokens">token list to merge</param>
        public void MergeIntoSet(IEnumerable<T> firstTokens)
        {
            AddUniqueTokens(firstTokens);
        }

        /// <summary>
        /// Merging into the list.
        /// </summary>
        /// <param name="firstTokens">token list to merge</param>
        public void MergeLists(IEnumerable<T> firstTokens)
        {
            AddTokens(firstTokens);
        }

        private void AddTokens(IEnumerable<T> tokenList)
        {
            foreach (var token in tokenList)
                MergedTokens.Add(token);
        }

        private void AddUniqueTokens(IEnumerable<T> tokenList)
        {
            foreach (var token in tokenList)
                TokenSet.Add(token);
        }
    }
}