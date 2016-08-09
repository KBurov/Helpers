using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_HttpHelper
{
    public abstract class HttpHelperContextBase : ContextBase
    {
        protected IHttpHelper _httpHelper;

        protected override void SetUp()
        {
            base.SetUp();

            _httpHelper = new HttpHelper();
        }
    }
}