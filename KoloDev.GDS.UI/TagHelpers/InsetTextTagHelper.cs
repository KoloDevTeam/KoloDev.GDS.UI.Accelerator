using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Inset text
    /// https://design-system.service.gov.uk/components/inset-text/
    /// </summary>
    public class GdsInsetTextTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.TagName = "div";
            output.Attributes.Add("class", "govuk-inset-text");
            output.Content.SetHtmlContent(content.GetContent());
        }
    }
}
