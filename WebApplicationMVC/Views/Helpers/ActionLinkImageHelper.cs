using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVC.Views.Helpers
{
    static public class ActionLinkImageHelper
    {
        public static MvcHtmlString ActionLinkImage(this HtmlHelper htmlHelper,
        string srcImg, string urlHref, string cssClassHref, string cssClassImg, string title = "")
        {
            TagBuilder href = new TagBuilder("a");
            href.MergeAttribute("href", urlHref);
            href.MergeAttribute("title", title);

            if (string.IsNullOrEmpty(cssClassHref) == false)
            {
                href.AddCssClass(cssClassHref);
            }

            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", srcImg);
            img.MergeAttribute("alt", title);
            if (string.IsNullOrEmpty(cssClassImg) == false)
            {
                img.AddCssClass(cssClassImg);
            }
            href.InnerHtml = img.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(href.ToString(TagRenderMode.Normal));
        }
    }
}