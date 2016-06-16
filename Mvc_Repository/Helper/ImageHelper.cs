using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Repository.Helper
{
    public static class ImageHelper
    {
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            string imagehtml = string.Format("<img src='{0}' alt='{1}' />", src, alt);
            return MvcHtmlString.Create(imagehtml);
        }
        public static IHtmlString Image(this HtmlHelper helper, string id, string src, string alt)
        {
            TagBuilder builder = new TagBuilder("img");
            builder.GenerateId(id);
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}