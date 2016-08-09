using System;

using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page.with_not_null_form_name.with_one_form_in_html_page
{
    public sealed class when_call_GetFormAction_with_existing_form_name : HttpHelperContext
    {
        public when_call_GetFormAction_with_existing_form_name()
        {
            SetUp();
        }

        [Fact]
        public void then_return_then_return_form_action_enumerable_with_one_element_version_with_name_action_order()
        {
            var actions = _httpHelper.GetFormAction(_htmlPageWithOneFormNameActionOrder, _formNames[0]);

            Assert.NotNull(actions);
            Assert.Single(actions, action => action.Equals(_formActions[0], StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void then_return_then_return_form_action_enumerable_with_one_element_version_with_action_name_order()
        {
            var actions = _httpHelper.GetFormAction(_htmlPageWithOneFormActionNameOrder, _formNames[0]);

            Assert.NotNull(actions);
            Assert.Single(actions, action => action.Equals(_formActions[0], StringComparison.InvariantCultureIgnoreCase));
        }
    }
}