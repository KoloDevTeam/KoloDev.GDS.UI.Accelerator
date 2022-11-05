using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    [HtmlTargetElement("gds-fieldset")]
    public class GdsFieldsetTagHelper : TagHelper
    {
        public string Heading { get; set; }
        public GdsFieldsetHeadingSize HeadingSize { get; set; } = GdsFieldsetHeadingSize.l;

        public enum GdsFieldsetHeadingSize
        {
            s, m, l, xl
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();

            output.TagName = "fieldset";
            output.Attributes.Add("class", "govuk-fieldset");

            var legendHtml = $@"<legend class=""govuk-fieldset__legend govuk-fieldset__legend--{ HeadingSize }"">
                                <h1 class=""govuk-fieldset__heading"">
                                  { Heading }
                                </h1>
                              </legend>";

            output.PreContent.SetHtmlContent(legendHtml);
            output.Content.SetHtmlContent(childContent);
        }
    }
}
