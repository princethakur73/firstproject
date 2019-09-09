using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication
{
    public static class BootstrapHelpers
    {
        public static IHtmlString BootstrapLabelFor<TModel, TProp>(
                this HtmlHelper<TModel> helper,
                Expression<Func<TModel, TProp>> property, int col = 2)
        {
            return helper.LabelFor(property, new
            {
                @class = string.Format("col-md-{0} control-label", col)
            });
        }

        public static IHtmlString BootstrapLabel(
                this HtmlHelper helper,
                string propertyName)
        {
            return helper.Label(propertyName, new
            {
                @class = "col-md-2 control-label"
            });
        }
    }
}