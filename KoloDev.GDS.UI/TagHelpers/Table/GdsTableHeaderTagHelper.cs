using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    [HtmlTargetElement("gds-table-header", ParentTag = "gds-table")]
    [RestrictChildren("gds-table-row")]
    public class GdsTableHeaderTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            output.TagName = "thead";
            output.Attributes.Add("class", "govuk-table__head");
            output.Content.SetHtmlContent(childContent);
        }
    }
}