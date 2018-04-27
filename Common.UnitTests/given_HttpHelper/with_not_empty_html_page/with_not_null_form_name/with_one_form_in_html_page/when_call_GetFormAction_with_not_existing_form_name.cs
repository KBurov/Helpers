using AutoFixture;

using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page.with_not_null_form_name.with_one_form_in_html_page
{
    public sealed class when_call_GetFormAction_with_not_existing_form_name : HttpHelperContext
    {
        public when_call_GetFormAction_with_not_existing_form_name()
        {
            SetUp();
        }

        [Fact]
        public void then_return_empty_form_action_enumerable_version_with_name_action_order()
        {
            var fixture = new Fixture();
            var formName = fixture.Create<string>();

            var actions = _httpHelper.GetFormAction(_htmlPageWithOneFormNameActionOrder, formName);

            Assert.NotNull(actions);
            Assert.Empty(actions);
        }

        [Fact]
        public void then_return_empty_form_action_enumerable_version_with_action_name_order()
        {
            var fixture = new Fixture();
            var formName = fixture.Create<string>();

            var actions = _httpHelper.GetFormAction(_htmlPageWithOneFormActionNameOrder, formName);

            Assert.NotNull(actions);
            Assert.Empty(actions);
        }
    }
}