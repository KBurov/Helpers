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
        /// <param name="url">the URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">the prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        public string Get(string url, Encoding preferedEncoding = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

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
        #endregion
    }
}