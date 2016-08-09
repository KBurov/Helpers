using System.Linq;

using Xunit;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page.with_null_form_name.with_several_forms_in_html_page
{
    public sealed class when_call_GetFormAction : HttpHelperContext
    {
        public when_call_GetFormAction()
        {
            SetUp();
        }

        [Fact]
        public void then_return_form_action_enumerable_with_all_actions()
        {
            var actions = _httpHelper.GetFormAction(_htmlPageWithSeveralForms);

            Assert.NotNull(actions);

            var actionList = actions.ToList();

            Assert.True(_formActions.All(actionList.Contains) && _formActions.Count == actionList.Count);
        }
    }
}