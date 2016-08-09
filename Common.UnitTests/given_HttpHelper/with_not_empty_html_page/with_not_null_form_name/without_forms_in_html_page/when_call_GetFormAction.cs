using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page.with_not_null_form_name.without_forms_in_html_page
{
    public sealed class when_call_GetFormAction : HttpHelperContext
    {
        public when_call_GetFormAction()
        {
            SetUp();
        }

        [Fact]
        public void then_return_empty_form_action_enumerable()
        {
            var actions = _httpHelper.GetFormAction(_htmlPageWithoutForms);

            Assert.NotNull(actions);
            Assert.Empty(actions);
        }
    }
}