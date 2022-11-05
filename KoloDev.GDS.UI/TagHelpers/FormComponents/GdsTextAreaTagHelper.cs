using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsTextareaTagHelper : TagHelper
    {
        public string Label { get; set; } = "Can you provide more detail?";
        public bool SmallHeading { get; set; } = false;
        public string Id { get; set; } = "more-detail";
        public string Name { get; set; } = "more-detail";
        public string Hint { get; set; } = "Do not include personal or financial information, like your National Insurance number or credit card details.";
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "Enter more detail";
        public string Value { get; set; } = string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";
            var largeLabel = "";

            if (!SmallHeading)
            {
                largeLabel = "govuk-label--l";
            }

            if (!IsValid)
            {
                errorInput = "govuk-textarea--error";
                errorOnGroup = "govuk-form-group--error";
                errorMessage = $@"<span id=""{ Id }-error"" class=""govuk-error-message"">
                                     <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                                  </span>";
            }

            output.TagName = "div";
            output.Attributes.Add("class", $"govuk-form-group { errorOnGroup }");

            var labelTemplate = $@"<h1 class=""govuk-label-wrapper"">
                                    <label class=""govuk-label {largeLabel}"" for=""{ Id }"">
                                      { Label }
                                    </label>
                                  </h1>";
            var inputTemplate =
                $@"<textarea class=""govuk-textarea { errorInput }"" id=""{ Id }"" name=""{ Name }"" rows=""5"" aria-describedby=""{ Id }-hint"">{Value}</textarea>";

            output.Content.SetHtmlContent(labelTemplate + errorMessage + inputTemplate);
        }
    }
}