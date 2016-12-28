using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers.Common
{
    /// <summary>
    /// Helper methods to GET/POST HTTP methods and process received HTML pages.
    /// Implements <see cref="IHttpHelper"/>.
    /// </summary>
    public sealed class HttpHelper : IHttpHelper
    {
        private const RegexOptions RegularExpressionOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline;

        #region IHttpHelper implementation
        /// <summary>
        /// Implements HTTP GET method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">a prefered encoding for received HTML page</param>
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
        /// <param name="preferedEncoding">a prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        public string Get(Uri uri, Encoding preferedEncoding)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

            return InternalGet(request, preferedEncoding);
        }

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="url">a URI that identifies the Internet resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        public string Post(string url, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            return InternalPost(request, postData, preferedDataEncoding, preferedEncoding);
        }

        /// <summary>
        /// Implements HTTP POST method.
        /// </summary>
        /// <param name="uri">a <see cref="Uri"/> containing the URI of the requested resource</param>
        /// <param name="postData">a data which will be sent in POST</param>
        /// <param name="preferedDataEncoding">a prefered encoding for <paramref name="postData"/></param>
        /// <param name="preferedEncoding">a prefered encoding for result</param>
        /// <returns>A result of HTTP POST method for provided parameters</returns>
        public string Post(Uri uri, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(uri);

            return InternalPost(request, postData, preferedDataEncoding, preferedEncoding);
        }

        /// <summary>
        /// Returns value of form "action" attribute.
        /// </summary>
        /// <param name="htmlPage">a HTML page content</param>
        /// <param name="formName">a form name</param>
        /// <returns>A collection of attribute "action" values</returns>
        public IEnumerable<string> GetFormAction(string htmlPage, string formName = null)
        {
            if (formName != null) {
                var regex = new Regex(
                    $@"(?:<form[^>]*?(?:(?:name=""{formName}"")[^>]*?action=""(?<action1>[^""]*))|(?:action=""(?<action2>[^""]*)""[^>]*?(?:name=""{formName}"")))",
                    RegularExpressionOptions);
                var actionMatches = regex.Matches(htmlPage);

                foreach (Match match in actionMatches) {
                    if (match.Success) {
                        if (match.Groups["action1"].Success) {
                            yield return match.Groups["action1"].Value;
                        }

                        if (match.Groups["action2"].Success) {
                            yield return match.Groups["action2"].Value;
                        }
                    }
                }
            }
            else {
                var regex = new Regex(@"(?:<form\s*[^>]*?action=""(?<action>[^""]*))", RegularExpressionOptions);
                var actionMatches = regex.Matches(htmlPage);

                foreach (Match match in actionMatches) {
                    if (match.Success) {
                        yield return match.Groups["action"].Value;
                    }
                }
            }
        }
        #endregion

        private static string InternalGet(HttpWebRequest request, Encoding preferedEncoding)
        {
            return InternalProcessReceiveStream(request, preferedEncoding);
        }

        private static string InternalPost(HttpWebRequest request, string postData, Encoding preferedDataEncoding, Encoding preferedEncoding)
        {
            var postBytes = postData != null
                                ? preferedDataEncoding?.GetBytes(postData) ?? Encoding.UTF8.GetBytes(postData)
                                : new byte[0];

            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            var postStream = request.GetRequestStream();

            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Close();

            return InternalProcessReceiveStream(request, preferedEncoding);
        }

        private static string InternalProcessReceiveStream(HttpWebRequest request, Encoding preferedEncoding)
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

            throw new HttpException($"Could not process {request.RequestUri}");
        }
    }
}