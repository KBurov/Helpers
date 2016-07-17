using System;
using System.IO;
using System.Net;
using System.Text;

namespace Helpers.Common
{
    /// <summary>
    /// Helper methods to GET/POST HTTP methods and process received HTML pages.
    /// Implements <see cref="IHttpHelper"/>.
    /// </summary>
    public sealed class HttpHelper : IHttpHelper
    {
        #region IHttpHelper implementation
        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">the prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        public string Get(string url, Encoding preferedEncoding = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            return InternalGet(request, preferedEncoding);
        }

        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="preferedEncoding">the prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        public string Get(Uri uri, Encoding preferedEncoding)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

            return InternalGet(request, preferedEncoding);
        }
        #endregion

        private static string InternalGet(HttpWebRequest request, Encoding preferedEncoding)
        {
            using (var response = (HttpWebResponse) request.GetResponse()) {
                if (response.StatusCode == HttpStatusCode.OK) {
                    var receiveStream = response.GetResponseStream();

                    if (receiveStream != null) {
                        using (var reader = preferedEncoding != null || response.CharacterSet != null
                                                ? new StreamReader(receiveStream, preferedEncoding ?? Encoding.GetEncoding(response.CharacterSet))
                                                : new StreamReader(receiveStream)) {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }

            throw new HttpException("Could not GET page");
        }
    }
}