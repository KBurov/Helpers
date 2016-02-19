using System;
using System.Diagnostics.Contracts;

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
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");
            Contract.Ensures(Contract.Result<string>() != null);

            if (s.Length > 1) {
                return char.ToUpper(s[0]) + s.Substring(1);
            }

            return s.ToUpper();
        }

        /// <summary>
        /// Converts the specified string to string with reverted value.
        /// </summary>
        /// <param name="s">the string to convert</param>
        /// <returns>the specified string converted to string with reverted value</returns>
        public static string Reverse(this string s)
        {
            // TODO: Look at http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");
            Contract.Ensures(Contract.Result<string>() != null);

            if (s == string.Empty) {
                return string.Empty;
            }

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
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");

            int dummy;

            return !string.IsNullOrWhiteSpace(s) && int.TryParse(s, out dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="uint" />.
        /// </summary>
        /// <param name="s">a string value</param>
        /// <returns>true is <paramref name="s"/> contains valid <see cref="uint"/> value</returns>
        public static bool IsUInt(this string s)
        {
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");

            uint dummy;

            return !string.IsNullOrWhiteSpace(s) && uint.TryParse(s, out dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="decimal" />.
        /// </summary>
        /// <param name="s">a string value</param>
        /// <returns>true is <paramref name="s"/> contains valid <see cref="decimal"/> value</returns>
        public static bool IsDecimal(this string s)
        {
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");

            decimal dummy;

            return !string.IsNullOrWhiteSpace(s) && decimal.TryParse(s, out dummy);
        }
        #endregion
    }
}