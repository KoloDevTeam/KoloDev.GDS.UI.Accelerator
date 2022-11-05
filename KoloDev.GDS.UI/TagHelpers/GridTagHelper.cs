using KoloDev.GDS.UI.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Grid
    /// </summary>
    [RestrictChildren("gds-grid-column")]
    public class GdsGridRowTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();
            output.TagName = "div";
            output.Attributes.Add("class", "govuk-grid-row");
        }
    }

    /// <summary>
    /// GDS Column
    /// </summary>
    [HtmlTargetElement("gds-grid-column", ParentTag = "gds-grid-row")]
    public class GdsGridColumnTagHelper : TagHelper
    {
        public GridColumnSize Size { get; set; } = GridColumnSize.half;
        public GridFromDesktopColumnSize? FromDesktopColumnSize { get; set; }

        public enum GridColumnSize
        { 
            [Description("full")]
            full,
            [Description("one-half")]
            half,
            [Description("one-quarter")]
            oneQuarter,
            [Description("two-quarters")]
            twoQuarters,
            [Description("three-quarters")]
            threeQuarters,
            [Description("one-third")]
            oneThird,
            [Description("two-thirds")]
            twoThirds
        }

        public enum GridFromDesktopColumnSize
        {
            [Description("full-from-desktop")]
            full,
            [Description("one-half-from-desktop")]
            half,
            [Description("one-quarter-from-desktop")]
            oneQuarter,
            [Description("two-quarters-from-desktop")]
            twoQuarters,
            [Description("three-quarters-from-desktop")]
            threeQuarters,
            [Description("one-third-from-desktop")]
            oneThird,
            [Description("two-thirds-from-desktop")]
            twoThirds
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            output.TagName = "div";

            var size = Size.DescriptionAttr();
            if (FromDesktopColumnSize != null)
            {
                var fromDTSize = FromDesktopColumnSize.DescriptionAttr();
                size += " " + fromDTSize;
            }

            output.Attributes.Add("class", "govuk-grid-column-" + size);
        }
    }
}
