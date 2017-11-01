using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Helpers.Common.Extensions
{
    /// <summary>
    /// The set of extension methods for <see cref="string" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Contains possible empty values for string except <see cref="string.Empty"/>.
        /// </summary>
        public static IList<string> EmptyValues { get; } = new List<string>();

        /// <summary>
        /// Returns true if <paramref name="str"/> either is null or empty or contains one of values from <see cref="EmptyValues"/>.
        /// </summary>
        /// <param name="str">a string value</param>
        /// <returns>true if <paramref name="str"/> either is null or empty or contains one of values from <see cref="EmptyValues"/></returns>
        public static bool IsEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            if (EmptyValues.Count > 0) {
                var trimValue = str.Trim();

                return EmptyValues.Any(emptyValue => trimValue.Equals(emptyValue, StringComparison.InvariantCultureIgnoreCase));
            }

            return false;
        }

        /// <summary>
        /// Converts the specified string to string with the first capital letter.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>the specified string converted to string with the first capital letter</returns>
        public static string FirstCharToUpper(this string str)
        {
            // http://stackoverflow.com/questions/4135317/make-first-letter-of-a-string-upper-case-for-maximum-performance
            if (str == null)
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} cannot be null");

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        /// <summary>
        /// Converts the specified string to string with reverted value.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>the specified string converted to string with reverted value</returns>
        public static string SimpleReverse(this string str)
        {
            // TODO: Look at http://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
            if (str == null)
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} cannot be null");

            if (str == string.Empty)
                return string.Empty;


            var charArray = str.ToCharArray();
            Array.Reverse(charArray);

            return new string(charArray);
        }

        #region Is... methods
        /// <summary>
        /// Returns true if <paramref name="str" /> contains <see cref="int" />.
        /// </summary>
        /// <param name="str">a string value</param>
        /// <returns>true is <paramref name="str"/> contains valid <see cref="int"/> value</returns>
        public static bool IsInt(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} cannot be null");


            return !string.IsNullOrWhiteSpace(str) && int.TryParse(str, out var dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="str" /> contains <see cref="uint" />.
        /// </summary>
        /// <param name="str">a string value</param>
        /// <returns>true is <paramref name="str"/> contains valid <see cref="uint"/> value</returns>
        public static bool IsUInt(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} cannot be null");


            return !string.IsNullOrWhiteSpace(str) && uint.TryParse(str, out var dummy);
        }

        /// <summary>
        /// Returns true if <paramref name="str" /> contains <see cref="decimal" />.
        /// </summary>
        /// <param name="str">a string value</param>
        /// <returns>true is <paramref name="str"/> contains valid <see cref="decimal"/> value</returns>
        public static bool IsDecimal(this string str)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str), $"{nameof(str)} cannot be null");


            return !string.IsNullOrWhiteSpace(str) && decimal.TryParse(str, out var dummy);
        }
        #endregion

        #region Parse... methods
        /// <summary>
        /// Returns converted from <paramref name="str"/> integer value if it possible, otherwise null.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>converted from <paramref name="str"/> integer value if it possible, otherwise null</returns>
        public static int? ParseInt(this string str)
        {
            if (str.IsEmpty())
                return null;

            return int.TryParse(str, out var result) ? result : (int?) null;
        }

        /// <summary>
        /// Returns converted from <paramref name="str"/> decimal value if it possible, otherwise null.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>converted from <paramref name="str"/> decimal value if it possible, otherwise null</returns>
        public static decimal? ParseDecimal(this string str)
        {
            if (str.IsEmpty())
                return null;

            try {
                return decimal.Parse(str);
            }
            catch (FormatException) {
                return decimal.Parse(str, NumberStyles.Float);
            }
        }

        /// <summary>
        /// Returns converted from <paramref name="str"/> double value if it possible, otherwise null.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>converted from <paramref name="str"/> double value if it possible, otherwise null</returns>
        public static double? ParseDouble(this string str)
        {
            if (str.IsEmpty())
                return null;

            return double.TryParse(str, out var result) ? result : (double?) null;
        }

        /// <summary>
        /// Returns converted from <paramref name="str"/> date value if it possible, otherwise null.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>converted from <paramref name="str"/> date value if it possible, otherwise null</returns>
        public static DateTime? ParseDate(this string str)
        {
            if (str.IsEmpty())
                return null;

            return new DateTime(
                int.Parse(str.Substring(0, 4)),
                int.Parse(str.Substring(4, 2)),
                int.Parse(str.Substring(6, 2)));
        }

        /// <summary>
        /// Returns converted from <paramref name="str"/> time value if it possible, otherwise null.
        /// </summary>
        /// <param name="str">the string to convert</param>
        /// <returns>converted from <paramref name="str"/> time value if it possible, otherwise null</returns>
        public static TimeSpan? ParseTime(this string str)
        {
            if (str.IsEmpty())
                return null;

            return new TimeSpan(
                int.Parse(str.Substring(0, 2)),
                int.Parse(str.Substring(2, 2)),
                int.Parse(str.Substring(4, 2)));
        }
        #endregion
    }
}