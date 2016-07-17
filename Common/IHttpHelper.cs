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
        /// <param name="url">the URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">the prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string Get(string url, Encoding preferedEncoding = null);
    }
}