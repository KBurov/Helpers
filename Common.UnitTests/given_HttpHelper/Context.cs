using Helpers.TestFramework;

namespace Helpers.Common.UnitTests.given_HttpHelper
{
    public abstract class Context : ContextBase
    {
        protected IHttpHelper _httpHelper;

        protected Context()
        {
            SetUp();
        }

        protected sealed override void SetUp()
        {
            base.SetUp();

            _httpHelper = new HttpHelper();
        }
    }
}