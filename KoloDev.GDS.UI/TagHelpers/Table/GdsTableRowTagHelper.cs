using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    [HtmlTargetElement("gds-table-row")]
    [RestrictChildren("gds-table-heading","gds-table-cell")]
    public class GdsTableRowTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            output.TagName = "tr";
            output.Attributes.Add("class", "govuk-table__row");
            output.Content.SetHtmlContent(childContent);
        }
    }
}
