using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace Helpers.Common
{
    /// <summary>
    /// Contains code contracts definition for interface <see cref="IHttpHelper" />.
    /// </summary>
    [ContractClassFor(typeof(IHttpHelper))]
    // ReSharper disable once InconsistentNaming
    internal abstract class IHttpHelperContract : IHttpHelper
    {
        #region IHttpHelper implementation
        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string IHttpHelper.Get(string url, Encoding preferedEncoding)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(url), "url cannot be null or empty");

            return default(string);
        }

        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string IHttpHelper.Get(Uri uri, Encoding preferedEncoding)
        {
            Contract.Requires<ArgumentNullException>(uri != null, "uri cannot be null");

            return default(string);
        }

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        string IHttpHelper.Post(string url, string postData, Encoding preferedDataEncoding, Encoding preferedEncoding)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(url), "url cannot be null or empty");

            return default(string);
        }

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        string IHttpHelper.Post(Uri uri, string postData, Encoding preferedDataEncoding, Encoding preferedEncoding)
        {
            Contract.Requires<ArgumentNullException>(uri != null, "uri cannot be null");

            return default(string);
        }
        #endregion
    }
}