using System;
using System.Diagnostics.Contracts;
using System.Text;

namespace Helpers.Common
{
    /// <summary>
    /// Helper methods to GET/POST HTTP methods and process received HTML pages.
    /// </summary>
    [ContractClass(typeof(IHttpHelperContract))]
    public interface IHttpHelper
    {
        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string Get(string url, Encoding preferedEncoding = null);

        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string Get(Uri uri, Encoding preferedEncoding = null);

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        string Post(string url, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null);

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        string Post(Uri uri, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null);
    }
}