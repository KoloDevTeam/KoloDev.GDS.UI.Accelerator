using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsBreadcrumbContext
    {
        public List<IHtmlContent> ListItem { get; set; } = new(0);
    }

    [RestrictChildren("gds-breadcrumb-level")]
    public class GdsBreadcrumbTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsBreadcrumbContext();
            context.Items.Add(typeof(GdsBreadcrumbTagHelper), listContext);

            await output.GetChildContentAsync();

            output.TagName = "div";
            output.Attributes.Add("class", "govuk-breadcrumbs");

            output.Content.AppendHtml(@"<ol class=""govuk-breadcrumbs__list"">");
            foreach (var item in listContext.ListItem)
            {
                output.Content.AppendHtml(@"<li class=""govuk-breadcrumbs__list-item"">");
                output.Content.AppendHtml(item);
                output.Content.AppendHtml("</li>");
            }
            output.Content.AppendHtml(@"</ol>");
        }
    }

    [HtmlTargetElement("gds-breadcrumb-level", ParentTag = "gds-breadcrumb")]
    public class GdsBreadcrumbLevelTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsBreadcrumbContext)context.Items[typeof(GdsBreadcrumbTagHelper)];
            modalContext.ListItem.Add(childContent);
            output.SuppressOutput();
        }
    }
}
