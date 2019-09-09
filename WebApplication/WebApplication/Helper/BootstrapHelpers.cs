using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebApplication.Core.Common;

namespace WebApplication.Helper
{
    public static class BootstrapHelpers
    {
        public static IHtmlString BootstrapLabelFor<TModel, IProp>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, IProp>> property)
        {
            return helper.LabelFor(property, new
            {
                @class = "col-md-4 control-label"
            });

        }

        public static IHtmlString BootstrapLabel(
            this HtmlHelper helper,
            string propertyName)
        {
            return helper.Label(propertyName, new
            {
                @class = "col-md-4 control-label"
            });

        }

        public static IHtmlString BootstrapValidationMessageFor<TModel, IProp>(
            this HtmlHelper<TModel> helper,
            Expression<Func<TModel, IProp>> property)
        {
            return helper.ValidationMessageFor(property, "", new
            {
                @class = "text-danger"
            });

        }

        public static IHtmlString BootstrapValidationMessage<TModel, IProp>(
            this HtmlHelper helper,
            string propertyName)
        {
            return helper.ValidationMessage(propertyName, "", new
            {
                @class = "text-danger"
            });

        }

        public static MvcHtmlString Paging(this HtmlHelper helper, Pager pager, string action, string controller)
        {
            StringBuilder sb = new StringBuilder();



            // pager
            if (pager.EndPage > 1)
            {

                sb.AppendFormat("<ul class='pagination'>");

                if (pager.CurrentPage > 1)
                {
                    sb.AppendFormat("<li>");
                    sb.AppendFormat("<button type='submit' name='PageNo' value='1'> First </button>");
                    sb.AppendFormat("</li>");
                    sb.AppendFormat("<li>");
                    sb.AppendFormat("<button type='submit' name='PageNo' value='{0}'> Previous </button>", (pager.CurrentPage - 1));
                    sb.AppendFormat("</li>");
                }


                for (var page = pager.StartPage; page <= pager.EndPage; page++)
                {
                    sb.AppendFormat("<li class='{0}'>", (page == pager.CurrentPage ? "active" : ""));
                    sb.AppendFormat("<button type='submit' name='PageNo' value='{0}'> {1} </button>", page, page);
                    sb.AppendFormat("</li>");
                }


                if (pager.CurrentPage < pager.TotalPages)
                {
                    sb.AppendFormat("<li>");
                    sb.AppendFormat("<button type='submit' name='PageNo' value='{0}'> Next </button>", (pager.CurrentPage + 1));
                    sb.AppendFormat("</li>");
                    sb.AppendFormat("<li>");
                    sb.AppendFormat("<button type='submit' name='PageNo' value='{0}'> Last </a>", (pager.TotalPages));
                    sb.AppendFormat("</li>");
                }

            }

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}