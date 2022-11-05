using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsDetailsContext 
    {
        public IHtmlContent? Summary { get; set; } = null;
        public IHtmlContent? Content { get; set; } = null;
    }

    [RestrictChildren("gds-details-summary", "gds-details-content")]
    public class GdsDetailsTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsDetailsContext();
            context.Items.Add(typeof(GdsDetailsTagHelper), listContext);

            await output.GetChildContentAsync();

            output.TagName = "details";
            output.Attributes.Add("class", "govuk-details");
            output.Attributes.Add("data-module", "govuk-details");
            
            if (listContext.Summary != null)
            {
                output.Content.AppendHtml($@"<summary class=""govuk-details__summary""><span class=""govuk-details__summary-text"">");
                output.Content.AppendHtml(listContext.Summary);
                output.Content.AppendHtml(@"</span></summary>");
            }

            if (listContext.Content != null)
            {
                output.Content.AppendHtml(@"<div class=""govuk-details__text"">");
                output.Content.AppendHtml(listContext.Content);
                output.Content.AppendHtml("</div>");
            }
        }
    }

    [HtmlTargetElement("gds-details-summary", ParentTag = "gds-details")]
    public class GdsDetailsSummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsDetailsContext)context.Items[typeof(GdsDetailsTagHelper)];
            modalContext.Summary = childContent;
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-details-content", ParentTag = "gds-details")]
    public class GdsDetailsContentTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsDetailsContext)context.Items[typeof(GdsDetailsTagHelper)];
            modalContext.Content = childContent;
            output.SuppressOutput();
        }
    }

}
