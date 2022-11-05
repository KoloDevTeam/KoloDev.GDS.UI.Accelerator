using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    [HtmlTargetElement("gds-table-heading", ParentTag = "gds-table-row")]
    public class GdsTableHeadingTagHelper : TagHelper
    {
        public int ColSpan { get; set; } = 1;
        public string Label { get; set; } = string.Empty;
        public GdsTableTextAlignment Alignment { get; set; } = GdsTableTextAlignment.left;
        public bool Sortable { get; set; } = false;
        public string Controller { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string ParamName { get; set; } = string.Empty;
        public string CurrentSortField { get; set; } = string.Empty;

        public enum GdsTableTextAlignment
        {
            left, right, middle
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            output.TagName = "th";
            output.Attributes.Add("class", $"govuk-table__header { Alignment }");
            output.Attributes.Add("scope", "col");
            if (ColSpan > 1)
            {
                output.Attributes.Add("colspan", ColSpan);
            }
            output.Content.SetHtmlContent(childContent);
        }
    }
}
