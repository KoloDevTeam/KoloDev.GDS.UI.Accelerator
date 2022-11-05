using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// Tag helpers for GDS Typography
    /// https://design-system.service.gov.uk/styles/typography/
    /// </summary>
    public class GdsParagraphTagHelper : TagHelper
    {
        /// The type of paragraph text - lead, standard etc.
        public BodyType Type { get; set; } = BodyType.none;
        /// The alignment of the paragraph text
        public AlignmentType Alignment { get; set; } = AlignmentType.none;
        /// The size override
        public FontSize Size { get; set; } = FontSize.none;
        /// Font weight
        public FontWeight Weight { get; set; } = FontWeight.none;

        /// Enums
        
        /// Alignment type
        public enum AlignmentType
        {
            left,
            centre,
            right,
            none
        }

        public enum BodyType
        {
            lead,
            regular,
            small,
            none
        }

        public enum FontSize
        {
            fourteen, sizteen, nineteen, twentyFour, twentySeven, thirtySix, fourtyEight, eighty, none
        }

        public enum FontWeight
        {
            regular,
            bold,
            none
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.TagName = "p";
            List<string> classes = new(0);

            switch (Type)
            {
                case BodyType.lead:
                    classes.Add("govuk-body-l");
                    break;
                case BodyType.regular:
                    classes.Add("govuk-body");
                    break;
                case BodyType.small:
                    classes.Add("govuk-body-s");
                    break;
                default:
                    classes.Add("govuk-body");
                    break;
            }

            switch (Alignment)
            {
                case AlignmentType.left:
                    classes.Add("govuk-!-text-align-left");
                    break;
                case AlignmentType.centre:
                    classes.Add("govuk-!-text-align-centre");
                    break;
                case AlignmentType.right:
                    classes.Add("govuk-!-text-align-right");
                    break;
            }

            switch (Size)
            {
                case FontSize.fourteen:
                    classes.Add("govuk-!-font-size-14");
                    break;
                case FontSize.sizteen:
                    classes.Add("govuk-!-font-size-16");
                    break;
                case FontSize.nineteen:
                    classes.Add("govuk-!-font-size-19");
                    break;
                case FontSize.twentyFour:
                    classes.Add("govuk-!-font-size-24");
                    break;
                case FontSize.twentySeven:
                    classes.Add("govuk-!-font-size-27");
                    break;
                case FontSize.thirtySix:
                    classes.Add("govuk-!-font-size-36");
                    break;
                case FontSize.fourtyEight:
                    classes.Add("govuk-!-font-size-48");
                    break;
                case FontSize.eighty:
                    classes.Add("govuk-!-font-size-80");
                    break;
            }

            switch (Weight)
            {
                case FontWeight.regular:
                    classes.Add("govuk-!-font-weight-regular");
                    break;
                case FontWeight.bold:
                    classes.Add("govuk-!-font-weight-bold");
                    break;
            }

            output.Attributes.Add("class", string.Join(" ", classes));

            output.Content.SetHtmlContent(content.GetContent());
        }
    }

    public class ATagHelper : TagHelper
    {
        public bool NoVisitedState { get; set; } = false;
        public bool InverseColor { get; set; } = false;
        public bool NoUnderline { get; set; } = false;
        public bool OpenInNewTab { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.TagName = "a";
            List<string> classes = new(1) { "govuk-link" };

            if (NoVisitedState)
            {
                classes.Add("govuk-link--no-visited-state");
            }

            if (InverseColor)
            {
                classes.Add("govuk-link--inverse");
            }

            if (NoUnderline)
            {
                classes.Add("govuk-link--no-underline");
            }

            if (OpenInNewTab)
            {
                output.Attributes.Add("rel", "noreferrer noopener");
                output.Attributes.Add("target", "_blank");
            }

            output.Attributes.Add("class", string.Join(" ", classes));
            output.Content.SetHtmlContent(content.GetContent());
        }
    }

}
