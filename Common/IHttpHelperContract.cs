﻿using System;
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
        /// <param name="url">the URI that identifies the Internet resource</param>
        /// <param name="preferedEncoding">the prefered encoding for received HTML page</param>
        /// <returns>A result of HTTP GET method for provided parameters</returns>
        string IHttpHelper.Get(string url, Encoding preferedEncoding)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(url), "url cannot be null or empty");

            return default(string);
        }
        #endregion
    }
}