using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc_Repository.Helper
{
    public static class radioHelper
    {
        /// <summary>
        /// 產生RadioButton
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="label"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="htmlClass"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioGenerate(this HtmlHelper helper, string label, string name, string value, object htmlAttributes)
        {
            var labelBuilder = new TagBuilder("label");
            labelBuilder.MergeAttribute("for", name);
            var builder = new TagBuilder("input");
            var BreakLine = new TagBuilder("br");
            builder.GenerateId(name);
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("type", "radio");
            builder.MergeAttribute("value", value);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            labelBuilder.InnerHtml = builder.ToString() + label;
            
            return MvcHtmlString.Create(labelBuilder.ToString() + BreakLine.ToString(TagRenderMode.SelfClosing));
            
        }
        public static IHtmlString ArrayCheckBoxFor<TModel, TArray>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TArray[]>> expression, TArray value)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("type", "checkbox");
            tagBuilder.Attributes.Add("name", metadata.PropertyName);
            tagBuilder.Attributes.Add("value", value.ToString());

            TArray[] propertyValue = metadata.Model as TArray[];
            bool isContainedInArray = propertyValue != null && propertyValue.Contains(value);
            if (isContainedInArray)
                tagBuilder.Attributes.Add("checked", "checked");

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }

    }
    public static class LabelExtensions
    {
        public static string Label(this HtmlHelper helper, string target, string text)
        {
            return String.Format("<label for='{0}'>{1}</label>", target, text);

        }
    }

}