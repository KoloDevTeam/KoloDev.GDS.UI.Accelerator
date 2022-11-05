using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.Table
{
    /// <summary>
    /// Tag helper to output a GDS table
    /// </summary>
    [RestrictChildren("gds-table-header","gds-table-body")]
    public class GdsTableTagHelper : TagHelper
    {
        /// <summary>
        /// Table caption
        /// </summary>
        public string Caption { get; set; } = string.Empty;
        /// <summary>
        /// Denotes whether the first cell in each of the body rows should be a table header
        /// </summary>
        public bool FirstCellIsHeading { get; set; }
        /// <summary>
        /// Dictates how the table should react in responsive scenarios
        /// </summary>
        public GdsTableResponsiveMode ResponsiveMode { get; set; } = GdsTableResponsiveMode.none;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Vc { get; set; }
        /// <summary>
        /// Types of responsive mode
        /// </summary>
        public enum GdsTableResponsiveMode
        {
            /// <summary>
            /// Stack rows as cards
            /// </summary>
            stacked,
            /// <summary>
            /// Overflow table and scroll
            /// </summary>
            scroll,
            /// <summary>
            /// None, use GDS default behaviour
            /// </summary>
            none
        }

        /// <summary>
        /// Process table tag
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var caption = $@"<caption class=""govuk-table__caption govuk-table__caption--m"">{Caption}</caption>";
            var classNames = new List<string>(1){ "govuk-table" };

            if (ResponsiveMode == GdsTableResponsiveMode.stacked)
            {
                classNames.Add("govuk-table--responsive-stacked");
                Vc.ViewBag.KoloDevUI_Table_Stacked = true;
            }

            var childContent = await output.GetChildContentAsync();
            output.TagName = "table";
            output.Content.SetHtmlContent(childContent);
            output.PreContent.SetHtmlContent(caption);

            if (ResponsiveMode == GdsTableResponsiveMode.scroll)
            {
                classNames.Add("govuk-table--responsive-scroll");
                output.PreElement.SetHtmlContent(@"<div class=""gds-table--responsive-scroll-container"">");
                output.PostElement.SetHtmlContent(@"</div>");
            }

            output.Attributes.Add("class", string.Join(" ", classNames));
        }
    }
}
