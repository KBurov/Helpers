using System;

namespace Helpers.Common.Extensions
{
    /// <summary>
    /// The set of extension methods for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the specified string to string with the first capital letter.
        /// </summary>
        /// <param name="s">the string to convert</param>
        /// <returns>the specified string converted to string with the first capital letter</returns>
        public static string FirstCharToUpper(this string s)
        {
            // http://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-for-maximum-performance
            if (s == null)
                throw new ArgumentNullException(nameof(s), $"{nameof(s)} cannot be null");

            if (s.Length > 1)
                return char.ToUpper(s[0]) + s.Substring(1);

            return s.ToUpper();
        }

        /// <summary>
        /// Converts the specified string to string with reverted value.
        /// </summary>
        /// <param name="s">the string to convert</param>
        /// <returns>the specified string converted to string with reverted value</returns>
        public static string SimpleReverse(this string s)
        {
            // TODO: Look at http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
            if (s == null)
                throw new ArgumentNullException(nameof(s), $"{nameof(s)} cannot be null");

            if (s == string.Empty)
                return string.Empty;


            var charArray = s.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        #region Is... methods
        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="int" />.
        /// </summary>
        /// <param name="s">a string value</param>
        /// <returns>true is <paramref name="s"/> contains valid <see cref="int"/> value</returns>
        public static bool IsInt(this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s), $"{nameof(s)} cannot be null");


            return !string.IsNullOrWhiteSpace(s) && int.TryParse(s, out var dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="uint" />.
        /// </summary>
        /// <param name="s">a string value</param>
        /// <returns>true is <paramref name="s"/> contains valid <see cref="uint"/> value</returns>
        public static bool IsUInt(this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s), $"{nameof(s)} cannot be null");


            return !string.IsNullOrWhiteSpace(s) && uint.TryParse(s, out var dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="decimal" />.
        /// </summary>
        /// <param name="s">a string value</param>
        /// <returns>true is <paramref name="s"/> contains valid <see cref="decimal"/> value</returns>
        public static bool IsDecimal(this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s), $"{nameof(s)} cannot be null");


            return !string.IsNullOrWhiteSpace(s) && decimal.TryParse(s, out var dummy);
        }
        #endregion
    }
}