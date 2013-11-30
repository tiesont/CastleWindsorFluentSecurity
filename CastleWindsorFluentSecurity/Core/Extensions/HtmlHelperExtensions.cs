using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace CastleWindsorFluentSecurity.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string areaName = "", string iconClass = "", bool hasChildren = false, bool isArea = false)
        {
            var li = new TagBuilder("li");

            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");

            var area = htmlHelper.ViewContext.RouteData.DataTokens["area"];

            string currentArea = area != null ? area.ToString() : string.Empty;

            if (isArea)
            {
                if (areaName.Equals(currentArea, StringComparison.OrdinalIgnoreCase))
                {
                    li.AddCssClass("active");
                }
            }
            else if (hasChildren)
            {
                if (controllerName.Equals(currentController, StringComparison.OrdinalIgnoreCase)
                    && areaName.Equals(currentArea, StringComparison.OrdinalIgnoreCase))
                {
                    li.AddCssClass("active");
                }
            }
            else
            {
                if (actionName.Equals(currentAction, StringComparison.OrdinalIgnoreCase)
                    && controllerName.Equals(currentController, StringComparison.OrdinalIgnoreCase)
                    && areaName.Equals(currentArea, StringComparison.OrdinalIgnoreCase))
                {
                    li.AddCssClass("active");
                }
            }

            if (string.IsNullOrWhiteSpace(iconClass))
            {
                li.InnerHtml = htmlHelper.ActionLink(linkText, actionName, controllerName, new { area = areaName }, null).ToHtmlString();
            }
            else
            {
                var a = new TagBuilder("a");
                var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
                a.Attributes.Add("href", urlHelper.Action(actionName, controllerName, new { area = areaName }));
                a.InnerHtml = string.Format("<i class=\"{0}\"></i> {1}", iconClass, linkText);

                li.InnerHtml = a.ToString();
            }

            return new HtmlString(li.ToString());
        }
    }
}