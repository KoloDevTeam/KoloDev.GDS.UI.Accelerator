using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsSelectTagHelper : TagHelper
    {
        public string Id { get; set; } = "sort";
        public string Name { get; set; } = "sort";
        public string Label { get; set; } = "Sort by";
        public string Value { get; set; } = "";
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "You must select a valid option";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";

            var options = await output.GetChildContentAsync();

            if (!IsValid)
            {
                errorInput = "govuk-input--error";
                errorOnGroup = "govuk-form-group--error";
                errorMessage =
                $@"<span id=""{ Id }-error"" class=""govuk-error-message"">
                    <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                </span>";
            }

            output.TagName = "div";
            output.Attributes.Add("class", $"govuk-form-group { errorOnGroup }");

            var labelTemplate = $@"<label class=""govuk-label"" for=""{ Id }"">
                                    { Label }
                                  </label>";
            var inputTemplate = $@"<select class=""govuk-select { errorInput }"" id=""{ Id }"" name=""{ Name }"">
                                    { options.GetContent() }
                                  </select>";

            output.Content.SetHtmlContent(labelTemplate + errorMessage + inputTemplate);

        }
    }
}
