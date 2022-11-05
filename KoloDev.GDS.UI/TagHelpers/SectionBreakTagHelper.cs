using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Section break tag helper
    /// https://design-system.service.gov.uk/styles/typography/#section-break
    /// </summary>
    public class GdsSectionBreakTagHelper : TagHelper
    {
        public BreakSize BreakSizing { get; set; } = BreakSize.m;
        public enum BreakSize
        {
            xl, l, m, s
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "hr";
            switch (BreakSizing)
            {
                case BreakSize.xl:
                    output.Attributes.Add("class", "govuk-section-break govuk-section-break--xl govuk-section-break--visible");
                    break;
                case BreakSize.l:
                    output.Attributes.Add("class", "govuk-section-break govuk-section-break--l govuk-section-break--visible");
                    break;
                case BreakSize.m:
                    output.Attributes.Add("class", "govuk-section-break govuk-section-break--m govuk-section-break--visible");
                    break;
                case BreakSize.s:
                    output.Attributes.Add("class", "govuk-section-break govuk-section-break--visible");
                    break;
            }
        }
    }
}
