using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsCheckboxContext
    {
        public List<string> Checkboxes { get; set; } = new(0);
        public List<string> Conditional { get; set; } = new(0);
    }

    [RestrictChildren("gds-checkbox", "gds-checkbox-conditional")]
    public class GdsCheckboxesTagHelper : TagHelper
    {
        public string Label { get; set; } = "Which types of waste do you transport?";
        public bool SmallHeading { get; set; } = false;
        public string Hint { get; set; } = "Select all that apply.";
        public bool SmallCheckboxes { get; set; } = false;
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "You must select a valid option";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsCheckboxContext();
            context.Items.Add(typeof(GdsCheckboxesTagHelper), listContext);

            await output.GetChildContentAsync();

            var largeLabel = "";
            var errorMessage = "";
            var errorOnGroup = "";
            var smallBoxes = "";

            if (SmallCheckboxes)
            {
                smallBoxes = "govuk-checkboxes--small";
            }

            if (!SmallHeading)
            {
                largeLabel = "govuk-label--l";
            }

            if (!IsValid)
            {
                errorOnGroup = "govuk-form-group--error";
                errorMessage =
                $@"<span class=""govuk-error-message"">
                    <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                </span>";
            }

            var template = $@"<div class=""govuk-form-group {errorOnGroup}"">
                              <fieldset class=""govuk-fieldset"" aria-describedby=""waste-hint"">
                                <legend class=""govuk-fieldset__legend {largeLabel}"">
                                  <h1 class=""govuk-fieldset__heading"">
                                    { Label }
                                  </h1>
                                </legend>
                                { errorMessage }
                                <div id=""waste-hint"" class=""govuk-hint"">
                                  { Hint }
                                </div>
                                <div class=""govuk-checkboxes {smallBoxes}"" data-module=""govuk-checkboxes"">";
            output.Content.AppendHtml(template);
            foreach (var item in listContext.Checkboxes)
            {
                output.Content.AppendHtml(item);
            }
            output.Content.AppendHtml("</div></fieldset></div>");
        }
    }

    [HtmlTargetElement("gds-checkbox", ParentTag = "gds-checkboxes")]
    public class GdsCheckboxTagHelper : TagHelper
    {
        public string Id { get; set; } = "waste";
        public string Name { get; set; } = "waste";
        public string Hint { get; set; } = "";
        public string Value { get; set; } = "";
        public bool Checked { get; set; } = false;
        public string ControlsConditional { get; set; } = "";
        public bool IsOr { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var checkboxContext = (GdsCheckboxContext)context.Items[typeof(GdsCheckboxesTagHelper)];
            var label = await output.GetChildContentAsync();
            var isOr = "";
            var isOrBehaviour = "";
            var hintTemplate = "";
            var conditional = "";
            var checkedAttr = "";

            if (Checked)
            {
                checkedAttr = @"checked=""true""";
            }
            if (IsOr)
            {
                isOr = @"<div class=""govuk-checkboxes__divider"">or</div>";
                isOrBehaviour = @"data-behaviour=""exclusive""";
            }
            if (!string.IsNullOrEmpty(Hint))
            {
                hintTemplate = $@"<div id=""nationality-item-hint"" class=""govuk-hint govuk-checkboxes__hint"">
                                    { Hint }
                                </div>";
            }
            if (!string.IsNullOrEmpty(ControlsConditional))
            {
                conditional = $@"data-aria-controls=""{ControlsConditional}""";
            }

            var labelTemplate = $@"<label class=""govuk-label govuk-checkboxes__label"" for=""{Id}"">
                                    { label.GetContent() }
                                </label>";
            var inputTemplate = $@"<input class=""govuk-checkboxes__input"" {checkedAttr} id=""{Id}"" name=""{Name}"" type=""checkbox"" value=""{Value}"" {isOrBehaviour} {conditional}>";

            var checkbox = $@"{isOr}<div class=""govuk-checkboxes__item"">{inputTemplate} {labelTemplate} {hintTemplate}</div>";

            checkboxContext.Checkboxes.Add(checkbox);
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-checkbox-conditional", ParentTag = "gds-checkboxes")]
    public class GdsCheckboxConditionalTagHelper : TagHelper
    {
        public string ConditionId { get; set; } = "";
        public string Label { get; set; } = "";
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var checkboxContext = (GdsCheckboxContext)context.Items[typeof(GdsCheckboxesTagHelper)];

            var content = await output.GetChildContentAsync();

            var labelTemplate = $@"<div class=""govuk-checkboxes__conditional govuk-checkboxes__conditional--hidden"" id=""{ConditionId}"">
                                    { content.GetContent() }
                                  </div>";

            checkboxContext.Checkboxes.Add(labelTemplate);
            output.SuppressOutput();
        }
    }
}