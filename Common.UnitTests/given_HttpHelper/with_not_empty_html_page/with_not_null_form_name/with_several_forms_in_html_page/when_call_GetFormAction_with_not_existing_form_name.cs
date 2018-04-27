using AutoFixture;

using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page.with_not_null_form_name.with_several_forms_in_html_page
{
    public sealed class when_call_GetFormAction_with_not_existing_form_name : HttpHelperContext
    {
        public when_call_GetFormAction_with_not_existing_form_name()
        {
            SetUp();
        }

        [Fact]
        public void then_return_empty_form_action_enumerable()
        {
            var fixture = new Fixture();
            var formName = fixture.Create<string>();
            var actions = _httpHelper.GetFormAction(_htmlPageWithSeveralForms, formName);

            Assert.NotNull(actions);
            Assert.Empty(actions);
        }
    }
}