using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// GDS Tag Element Tag helper
    /// https://design-system.service.gov.uk/components/tag/
    /// </summary>
    public class GdsTagTagHelper : TagHelper
    {
        /// <summary>
        /// Type of tag
        /// </summary>
        public TagType Type { get; set; } = TagType.blue;

        /// <summary>
        /// Enum for the type of tag
        /// The primary Tag will output the default GDS darker blue tag.
        /// </summary>
        public enum TagType
        {
            primary, grey, green, turquoise, blue, purple, pink, red, orange, yellow
        }

        /// <summary>
        /// Process tag helper async
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            output.TagName = "strong";
            if(Type == TagType.primary)
            {
                output.Attributes.Add("class", $"govuk-tag");
            }
            else
            {
                output.Attributes.Add("class", $"govuk-tag govuk-tag--{ Type }");
            }

            await output.GetChildContentAsync();
            output.Content.SetHtmlContent(content.GetContent());
        }

    }
}
