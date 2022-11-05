using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.ErrorSummary
{
    public class GdsListContext
    {
        public List<IHtmlContent> ListItem { get; set; } = new(0);
    }

    /// <summary>
    /// GDS Error summary
    /// https://design-system.service.gov.uk/components/error-summary/
    /// </summary>
    [RestrictChildren("gds-error-summary-item")]
    public class ErrorSummaryTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsListContext();
            context.Items.Add(typeof(GdsListTagHelper), listContext);

            await output.GetChildContentAsync();

            var summaryHtml = $@"<div class=""govuk-error-summary"" aria-labelledby=""error-summary-title"" role=""alert"" tabindex=""-1"" data-module=""govuk-error-summary"">
                                  <h2 class=""govuk-error-summary__title"" id=""error-summary-title"">
                                    There is a problem
                                  </h2>
                                  <div class=""govuk-error-summary__body"">
                                    <ul class=""govuk-list govuk-error-summary__list"">";

            output.Content.AppendHtml(summaryHtml);

            foreach (var item in listContext.ListItem)
            {
                output.Content.AppendHtml(item);
            }

            output.Content.AppendHtml("</ul></div></div>");
        }
    }

    [HtmlTargetElement("gds-error-summary-item", ParentTag = "gds-error-summary")]
    public class ErrorSummaryItemTagHelper : TagHelper
    {
        public string TargetElement { get; set; } = String.Empty;
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsListContext)context.Items[typeof(GdsListTagHelper)];

            output.Content.AppendHtml($@"<li><a href=""#{ TargetElement }"">");
            output.Content.AppendHtml(childContent);
            output.Content.AppendHtml("</a></li>");

            modalContext.ListItem.Add(output.Content);
            output.SuppressOutput();
        }
    }
}
