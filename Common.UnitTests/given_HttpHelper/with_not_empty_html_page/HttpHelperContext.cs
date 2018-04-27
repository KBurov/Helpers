using System.Collections.Generic;
using System.Linq;
using System.Text;

using AutoFixture;

namespace Helpers.Common.UnitTests.given_HttpHelper.with_not_empty_html_page
{
    public abstract class HttpHelperContext : HttpHelperContextBase
    {
        private const int FormCount = 3;

        protected IList<string> _formNames;
        protected IList<string> _formActions;

        protected string _htmlPageWithoutForms;
        protected string _htmlPageWithOneFormNameActionOrder;
        protected string _htmlPageWithOneFormActionNameOrder;
        protected string _htmlPageWithSeveralForms;

        protected override void SetUp()
        {
            base.SetUp();

            var fixture = new Fixture {RepeatCount = FormCount};

            _formNames = fixture.CreateMany<string>().ToList();
            _formActions = fixture.CreateMany<string>().ToList();

            _htmlPageWithoutForms = fixture.Create<string>();
            _htmlPageWithOneFormNameActionOrder = $"{_htmlPageWithoutForms}<form name=\"{_formNames[0]}\" action=\"{_formActions[0]}\">{_htmlPageWithoutForms}";
            _htmlPageWithOneFormActionNameOrder = $"{_htmlPageWithoutForms}<form action=\"{_formActions[0]}\" name=\"{_formNames[0]}\">{_htmlPageWithoutForms}";

            var order = false;
            var stringBuilder = new StringBuilder(_htmlPageWithoutForms);

            for (var i = 0;i < _formNames.Count;i++) {
                stringBuilder.Append(order
                    ? $"<form name=\"{_formNames[i]}\" action=\"{_formActions[i]}\">"
                    : $"<form action=\"{_formActions[i]}\" name=\"{_formNames[i]}\">");

                order = !order;
            }

            stringBuilder.Append(_htmlPageWithoutForms);

            _htmlPageWithSeveralForms = stringBuilder.ToString();
        }
    }
}