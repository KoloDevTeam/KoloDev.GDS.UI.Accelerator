using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Warning Text
    /// https://design-system.service.gov.uk/components/warning-text/
    /// </summary>
    public class GdsWarningTextTagHelper : TagHelper
    {
        /// <summary>
        /// Process tag helper (async)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.TagName = "div";
            output.Attributes.Add("class", "govuk-warning-text");

            output.Content.AppendHtml(@"<span class=""govuk-warning-text__icon"" aria-hidden=""true"">!</span>
                                            <strong class=""govuk-warning-text__text"">
                                                <span class=""govuk-warning-text__assistive"">Warning</span>");
            output.Content.AppendHtml(content);
            output.Content.AppendHtml(@"</strong>");
        }
    }
}
