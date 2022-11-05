using KoloDev.GDS.UI.Extensions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsInputTagHelper : TagHelper
    {
        public string Id { get; set; } = "NO-ID-PROVIDED";
        public string Name { get; set; } = "NO-NAME-PROVIDED";
        public string Label { get; set; } = "Input";
        public string Hint { get; set; } = "";
        public string Value { get; set; } = "";
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "You must provide a valid entry";
        public bool SmallHeading { get; set; } = false;
        public string Prefix { get; set; } = null;
        public string Suffix { get; set; } = null;
        public bool Readonly { get; set; } = false;
        public bool Disabled { get; set; } = false;
        public int MaxLength { get; set; } = 0;
        public int? Min { get; set; } = null;
        public int? Max { get; set; } = null;
        public string Class { get; set; } = "";
        public InputType Type { get; set; } = InputType.text;
        public InputSizing Size { get; set; } = InputSizing.none;

        public enum InputSizing
        {
            [Description("2")]
            two,

            [Description("3")]
            three,

            [Description("4")]
            four,

            [Description("5")]
            five,

            [Description("10")]
            ten,

            [Description("20")]
            twenty,

            none
        }

        public enum InputType
        {
            button,
            checkbox,
            color,
            email,
            file,
            hidden,
            image,
            month,
            number,
            password,
            radio,
            range,
            reset,
            search,
            submit,
            tel,
            text,
            time,
            url,
            week
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var sizer = "";
            var headingSize = "";
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";
            var readOnly = "";
            var disableInput = "";
            var maxLength = "";
            var min = "";
            var max = "";

            if (!SmallHeading) { headingSize = "govuk-label--l"; }
            if (!IsValid)
            {
                errorInput = "govuk-input--error";
                errorOnGroup = "govuk-form-group--error";
                errorMessage =
                $@"<span id=""passport-issued-error"" class=""govuk-error-message"">
                    <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                </span>";
            }

            if (Size != InputSizing.none)
            {
                sizer = "govuk-input--width-" + Size.DescriptionAttr();
            }

            if (Prefix != null)
            {
            }

            if (Readonly)
            {
                readOnly = @"readonly=""true""";
            }

            if (Disabled)
            {
                disableInput = @"disabled=""true""";
            }

            if (MaxLength > 0)
            {
                maxLength = $@"maxlength=""{MaxLength}""";
            }

            if (Min is not null)
            {
                min = $@"min=""{Min}""";
            }

            if (Max is not null)
            {
                max = $@"min=""{Max}""";
            }

            var template = $@"<div class=""govuk-form-group { errorOnGroup } { Class } { (Type == InputType.hidden ? "hidden" : "") }"">
                              <h1 class=""govuk-label-wrapper"">
                                <label class=""govuk-label { headingSize }"" for=""input-{ Id }"">
                                  { Label }
                                </label>
                              </h1>
                                <div id=""input-{ Id }-hint"" class=""govuk-hint"">
                                    { Hint }
                                </div>
                                { errorMessage }
                              <input class=""govuk-input { errorInput } { sizer }"" {maxLength} {min} {max} {readOnly} {disableInput} id=""input-{ Id }"" name=""{ Name }"" type=""{ Type }"" value=""{ Value }"">
                            </div>";

            output.Content.SetHtmlContent(template);
        }
    }
}