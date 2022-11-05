using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsFileUpload : TagHelper
    {
        public string Label { get; set; } = "Upload a file";
        public string Id { get; set; } = "file-upload";
        public string Name { get; set; } = "file";
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "The CSV must be smaller than 2MB";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";

            if (!IsValid)
            {
                errorInput = "govuk-file-upload--error";
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
            var inputTemplate = $@"<input class=""govuk-file-upload { errorInput }"" id=""{ Id }"" name=""{ Name }"" type=""file"">";

            output.Content.SetHtmlContent(labelTemplate + errorMessage + inputTemplate);

        }
    }
}
