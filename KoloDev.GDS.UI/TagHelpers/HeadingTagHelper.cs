using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Heading tag helper
    /// https://design-system.service.gov.uk/styles/typography/#headings
    /// </summary>
    public class GdsHeadingTagHelper : TagHelper
    {
        public HeadingSize Size { get; set; } = HeadingSize.xl;

        public enum HeadingSize
        {
            xl,
            l,
            m,
            s
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            switch (Size)
            {
                case HeadingSize.xl:
                    output.TagName = "h1";
                    output.Attributes.Add("class", "govuk-heading-xl");
                    break;
                case HeadingSize.l:
                    output.TagName = "h2";
                    output.Attributes.Add("class", "govuk-heading-l");
                    break;
                case HeadingSize.m:
                    output.TagName = "h3";
                    output.Attributes.Add("class", "govuk-heading-m");
                    break;
                case HeadingSize.s:
                    output.TagName = "h4";
                    output.Attributes.Add("class", "govuk-heading-s");
                    break;
            }
            output.Content.SetHtmlContent(content.GetContent());
        }
    }

    /// <summary>
    /// GDS Heading caption
    /// https://design-system.service.gov.uk/styles/typography/#headings-with-captions-typography-example-open
    /// </summary>
    [HtmlTargetElement("gds-heading-caption")]
    public class GdsHeadingCaptionTagHelper : TagHelper
    {
        public HeadingCaptionSize Size { get; set; } = HeadingCaptionSize.xl;

        public enum HeadingCaptionSize
        {
            xl,
            l,
            m
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            switch (Size)
            {
                case HeadingCaptionSize.xl:
                    output.TagName = "span";
                    output.Attributes.Add("class", "govuk-caption-xl");
                    break;
                case HeadingCaptionSize.l:
                    output.TagName = "span";
                    output.Attributes.Add("class", "govuk-caption-l");
                    break;
                case HeadingCaptionSize.m:
                    output.TagName = "span";
                    output.Attributes.Add("class", "govuk-caption-m");
                    break;
            }
            output.Content.SetHtmlContent(content.GetContent());
        }
    }

}
