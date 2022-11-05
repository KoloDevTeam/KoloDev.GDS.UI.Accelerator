using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    [HtmlTargetElement("gds-table-body", ParentTag = "gds-table")]
    [RestrictChildren("gds-table-row")]
    public class GdsTableBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            output.TagName = "tbody";
            output.Attributes.Add("class", "govuk-table__body");
            output.Content.SetHtmlContent(childContent);
        }
    }
}
