using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Todo.Api.Model;

namespace Todo.Api.Helpers
{
    public static class NavbarHelper
    {
        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
            => new HtmlString("<strong>Hello World</strong>");

        public static IHtmlContent HelloWorldString(this IHtmlHelper htmlHelper, bool side)
        {
            StringBuilder strb = new StringBuilder();
            IList<Navbar> listNavbar = (List<Navbar>)htmlHelper.ViewData.Model;
            foreach (var item in listNavbar.Where(x=>x.righSide.Equals(side))) //RIGHSIDE NAVBAR
            {
                if (item.isParent == false && item.parentId == 0)
                {
                    strb.Append("<li>");
                    strb.Append("< a class=\"@");
                    strb.Append(item.activeli);
                    strb.Append("href=\"@Url.Action(");
                    strb.Append(item.action);
                    strb.Append(",");
                    strb.Append(item.controller);
                    strb.Append(")\">");
                    strb.Append("<span class=\"@");
                    strb.Append(item.imageClass);
                    strb.Append("\"");
                    strb.Append("title=\"@");
                    strb.Append(item.tooltip);
                    strb.Append("\"></span>");
                    strb.Append("</a>");
                    strb.Append("</li>");

                }
            }
            return new HtmlString(strb.ToString()); //strb.ToString();
        }

    }
}
