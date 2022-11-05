using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsRadiosContext
    {
        public List<string> Radios { get; set; } = new(0);
    }

    [RestrictChildren("gds-radio", "gds-radio-conditional")]
    public class GdsRadiosTagHelper : TagHelper
    {
        public string Label { get; set; } = "Where do you live?";
        public string Hint { get; set; } = "";
        public bool SmallCheckboxes { get; set; } = false;
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "You must select a valid option";
        public bool IsConditional { get; set; }
        public bool Inline { get; set; } = false;
        public bool SmallHeading { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsCheckboxContext();
            context.Items.Add(typeof(GdsCheckboxesTagHelper), listContext);

            await output.GetChildContentAsync();

            var errorMessage = "";
            var errorOnGroup = "";
            var smallBoxes = "";
            var hintTemplate = "";
            var conditional = "";
            var smallHeadingClass = "";
            var inlineClass = "";

            if (SmallCheckboxes)
            {
                smallBoxes = "govuk-radios--small";
            }

            if (!string.IsNullOrEmpty(Hint))
            {
                hintTemplate = $@"<div id=""nationality-item-hint"" class=""govuk-hint"">
                                    { Hint }
                                </div>";
            }

            if (IsConditional)
            {
                conditional = "govuk-radios--conditional";
            }

            if (!IsValid)
            {
                errorOnGroup = "govuk-form-group--error";
                errorMessage =
                $@"<span class=""govuk-error-message"">
                    <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                </span>";
            }

            if (!SmallHeading)
            {
                smallHeadingClass = "govuk-fieldset__legend--l";
            }

            if (Inline)
            {
                inlineClass = "govuk-radios--inline";
            }

            var template = $@"<div class=""govuk-form-group { errorOnGroup }"">
                                  <fieldset class=""govuk-fieldset"">
                                    <legend class=""govuk-fieldset__legend { smallHeadingClass }"">
                                      <h1 class=""govuk-fieldset__heading"">
                                        { Label }
                                      </h1>
                                    </legend>
                                    { hintTemplate }
                                    { errorMessage }
                                    <div class=""govuk-radios { smallBoxes } { conditional } { inlineClass }"">";
            output.Content.AppendHtml(template);
            foreach (var item in listContext.Checkboxes)
            {
                output.Content.AppendHtml(item);
            }
            output.Content.AppendHtml("</div></fieldset></div>");
        }
    }

    [HtmlTargetElement("gds-radio", ParentTag = "gds-radios")]
    public class GdsRadioTagHelper : TagHelper
    {
        public string Id { get; set; } = "waste";
        public string Name { get; set; } = "waste";
        public string Value { get; set; } = "";
        public string ControlsConditional { get; set; } = "";
        public bool Checked { get; set; } = false;
        public bool IsOr { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var checkboxContext = (GdsCheckboxContext)context.Items[typeof(GdsCheckboxesTagHelper)];
            var label = await output.GetChildContentAsync();
            var isOr = "";
            var conditional = "";

            if (IsOr)
            {
                isOr = @"<div class=""govuk-radios__divider"">or</div>";
            }

            if (!string.IsNullOrEmpty(ControlsConditional))
            {
                conditional = $@"data-aria-controls=""{ ControlsConditional }""";
            }

            var labelTemplate = $@"<label class=""govuk-label govuk-radios__label"" for=""{ Id }"">
                                        { label.GetContent() }
                                    </label>";
            var inputTemplate = $@"<input class=""govuk-radios__input"" id=""{ Id }"" name=""{ Name }"" type=""radio"" value=""{ Value }"" { conditional } { (Checked ? "checked" : "") }>";

            var radio = $@"{isOr}<div class=""govuk-radios__item"">{inputTemplate} {labelTemplate}</div>";

            checkboxContext.Checkboxes.Add(radio);
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-radio-conditional", ParentTag = "gds-radios")]
    public class GdsRadioConditionalTagHelper : TagHelper
    {
        public string ConditionId { get; set; } = "";
        public string Label { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var checkboxContext = (GdsCheckboxContext)context.Items[typeof(GdsCheckboxesTagHelper)];

            var content = await output.GetChildContentAsync();

            var labelTemplate = $@"<div class=""govuk-radios__conditional govuk-radios__conditional--hidden"" id=""{ConditionId}"">
                                            { content }
                                         </div>";

            checkboxContext.Checkboxes.Add(labelTemplate);
            output.SuppressOutput();
        }
    }
}