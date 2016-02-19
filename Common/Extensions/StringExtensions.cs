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
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string s)
        {
            Contract.Requires<ArgumentNullException>(s != null, "s cannot be null");
            Contract.Ensures(Contract.Result<string>() != null);

            if (s.Length > 1) {
                return char.ToUpper(s[0]) + s.Substring(1);
            }

            return s.ToUpper();
        }

        #region Is... methods
        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="int" />
        /// </summary>
        public static bool IsInt(this string s)
        {
            int dummy;

            return !string.IsNullOrWhiteSpace(s) && int.TryParse(s, out dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="uint" />
        /// </summary>
        public static bool IsUInt(this string s)
        {
            uint dummy;

            return !string.IsNullOrWhiteSpace(s) && uint.TryParse(s, out dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="s" /> contains <see cref="decimal" />
        /// </summary>
        public static bool IsDecimal(this string s)
        {
            decimal dummy;

            return !string.IsNullOrWhiteSpace(s) && decimal.TryParse(s, out dummy);
        }
        #endregion
    }
}