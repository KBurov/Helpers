using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Helpers.Common
{
    /// <inheritdoc />
    public sealed class HttpHelper : IHttpHelper
    {
        private const RegexOptions RegularExpressionOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline;

        #region IHttpHelper implementation
        /// <inheritdoc />
        public string Get(string url, Encoding preferedEncoding = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"{nameof(url)} cannot be null or empty", nameof(url));

            var request = (HttpWebRequest) WebRequest.Create(url);

            return InternalGet(request, preferedEncoding);
        }

        /// <inheritdoc />
        public string Get(Uri uri, Encoding preferedEncoding)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri), $"{nameof(uri)} cannot be null");

            var request = (HttpWebRequest) WebRequest.Create(uri);

            return InternalGet(request, preferedEncoding);
        }

        /// <inheritdoc />
        public string Post(string url, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException($"{nameof(url)} cannot be null or empty", nameof(url));

            var request = (HttpWebRequest) WebRequest.Create(url);

            return InternalPost(request, postData, preferedDataEncoding, preferedEncoding);
        }

        /// <inheritdoc />
        public string Post(Uri uri, string postData = null, Encoding preferedDataEncoding = null, Encoding preferedEncoding = null)
        {
            if (uri == null)
                throw new ArgumentNullException(nameof(uri), $"{nameof(uri)} cannot be null");

            var request = (HttpWebRequest) WebRequest.Create(uri);

            return InternalPost(request, postData, preferedDataEncoding, preferedEncoding);
        }

        /// <inheritdoc />
        public IEnumerable<string> GetFormAction(string htmlPage, string formName = null)
        {
            if (string.IsNullOrEmpty(htmlPage))
                throw new ArgumentException($"{nameof(htmlPage)} cannot be null or empty");

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