using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    [HtmlTargetElement("gds-table-cell", ParentTag = "gds-table-row")]
    public class GdsTableCellTagHelper : TagHelper
    {
        public int ColSpan { get; set; } = 1;
        public GdsTableTextAlignment Alignment { get; set; } = GdsTableTextAlignment.left;
        public bool IsHeading { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Vc { get; set; }

        public enum GdsTableTextAlignment
        {
            left, right, middle
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            if (IsHeading)
            {
                output.TagName = "th";
                output.Attributes.Add("class", $"govuk-table__header { Alignment }");
                output.Attributes.Add("scope", "row");
            }
            else
            {
                output.TagName = "td";
                output.Attributes.Add("class", $"govuk-table__cell { Alignment }");
            }
            
            output.Content.SetHtmlContent(childContent);
            
            if (ColSpan > 1)
            {
                output.Attributes.Add("colspan", ColSpan);
            }
        }
    }
}
