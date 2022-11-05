using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS success panel
    /// https://design-system.service.gov.uk/components/panel/
    /// </summary>
    public class GdsPanelTagBlocks
    {
        public IHtmlContent? Title { get; set; }
        public IHtmlContent? Body { get; set; }
    }

    [RestrictChildren("gds-panel-title","gds-panel-body")]
    public class GdsPanelTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsPanelTagBlocks();
            context.Items.Add(typeof(GdsPanelTagHelper), listContext);

            await output.GetChildContentAsync();

            output.TagName = "div";
            output.Attributes.Add("class", "govuk-panel govuk-panel--confirmation");

            if (listContext.Title != null)
            {
                output.Content.AppendHtml(@"<h1 class=""govuk-panel__title"">");
                output.Content.AppendHtml(listContext.Title);
                output.Content.AppendHtml(@"</h1>");
            }

            if (listContext.Body != null)
            {
                output.Content.AppendHtml(@"<div class=""govuk-panel__body"">");
                output.Content.AppendHtml(listContext.Body);
                output.Content.AppendHtml(@"</div>");
            }
        }
    }

    [HtmlTargetElement("gds-panel-title", ParentTag = "gds-panel")]
    public class PanelTitleTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsPanelTagBlocks)context.Items[typeof(GdsPanelTagHelper)];
            modalContext.Title = childContent;
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-panel-body", ParentTag = "gds-panel")]
    public class PanelBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsPanelTagBlocks)context.Items[typeof(GdsPanelTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}