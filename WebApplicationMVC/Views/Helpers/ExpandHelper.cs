using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVC.Views.Helpers
{
    static public class ExpandHelper
    {
        public static MvcHtmlString ActionLinkImage(this HtmlHelper htmlHelper,
        string srcImg, string urlHref, string cssClassHref = null, string cssClassImg = null, string title = "", string nameLink = null)
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

            if (string.IsNullOrEmpty(nameLink) == false)
            {
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("col-xs-10  text-center devicePadding deviceMenuName");
                span.InnerHtml = nameLink;

                href.InnerHtml = span.ToString() + @"<br />" + @"<br />" + img.ToString(TagRenderMode.SelfClosing);
            }

            return MvcHtmlString.Create(href.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString ButtonImageSubmit(this HtmlHelper htmlHelper, string nameButton, string cssClassButton, string buttonValue,
string srcImg, string cssClassImg, string title = "")
        {
            TagBuilder button = new TagBuilder("button");
            button.MergeAttribute("name", nameButton);
            button.MergeAttribute("type", "submit");
            if (string.IsNullOrEmpty(buttonValue) == false)
            {
                button.MergeAttribute("value", buttonValue);
            }

            if (string.IsNullOrEmpty(title) == false)
            {
                button.MergeAttribute("title", title);
            }
            else
            {
            }
            if (string.IsNullOrEmpty(cssClassButton) == false)
            {
                button.AddCssClass(cssClassButton);
            }
            else
            {
            }

            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", srcImg);
            img.MergeAttribute("alt", buttonValue);
            if (string.IsNullOrEmpty(cssClassImg) == false)
            {
                img.AddCssClass(cssClassImg);
            }
            button.InnerHtml = img.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(button.ToString(TagRenderMode.Normal));
        }
    }
}