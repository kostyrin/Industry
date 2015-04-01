using System;
using System.Web.Mvc;

namespace Industry.Front.Web.HtmlHelperExtensions
{
    public static class MenuExtensions
    {
        //<a href="@Url.Action("Index", "Shopper")"><i class="fa  fa-male fa-fw"></i> Покупатели</a>
        public static MvcHtmlString MenuItem(
            this HtmlHelper htmlHelper,
            string text,
            string action,
            string controller,
            string icon = "fa fa-circle-o",
            string liCssClass = null
        )
        {
            var li = new TagBuilder("li");
            if (!String.IsNullOrEmpty(liCssClass))
            {
                li.AddCssClass(liCssClass);
            }
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }
            li.InnerHtml = String.Format("<a href=\"{0}\"><i class=\"{2}\"></i>{1}</a>",
               new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(action, controller).ToString()
                , text, icon);
            return MvcHtmlString.Create(li.ToString());
        }
    }
}