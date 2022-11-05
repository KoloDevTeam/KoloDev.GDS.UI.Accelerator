using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsDateInputTagHelper : TagHelper
    {
        public string Id { get; set; } = "NO-ID-PROVIDED";
        public string Name { get; set; } = "NO-NAME-PROVIDED";
        public string Heading { get; set; } = "Date input";
        public string Hint { get; set; } = "For example, 27 3 2007";
        public DateTime? Value { get; set; } = null;
        public bool IsValid { get; set; } = true;
        public string ValidationMessage { get; set; } = "You must provide a valid date";
        public bool SmallHeading { get; set; } = false;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var headingSize = "";
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";
            var dayValue = "";
            var monthValue = "";
            var yearValue = "";

            if (!SmallHeading) { headingSize = "govuk-fieldset__legend--l"; }
            if (!IsValid)
            {
                errorInput = "govuk-input--error";
                errorOnGroup = "govuk-form-group--error";
                errorMessage =
                $@"<span id=""passport-issued-error"" class=""govuk-error-message"">
                    <span class=""govuk-visually-hidden"">Error:</span> { ValidationMessage }
                </span>";
            }
            if (Value != null)
            {
                dayValue = Value.Value.Day.ToString();
                monthValue = Value.Value.Month.ToString();
                yearValue = Value.Value.Year.ToString();
            }

            var template = $@"<div class=""govuk-form-group { errorOnGroup }"">
                              <fieldset class=""govuk-fieldset"" role=""group"" aria-describedby=""{ Id }-hint"">
                                <legend class=""govuk-fieldset__legend {headingSize}"">
                                  <h1 class=""govuk-fieldset__heading"">
                                    { Heading }
                                  </h1>
                                </legend>
                                <div id=""{ Id }-hint"" class=""govuk-hint"">
                                  { Hint }
                                </div>
                                { errorMessage }
                                <div class=""govuk-date-input"" id=""date-input-{ Id }"">
                                  <div class=""govuk-date-input__item"">
                                    <div class=""govuk-form-group"">
                                      <label class=""govuk-label govuk-date-input__label"" for=""day-input-{ Id }"">
                                        Day
                                      </label>
                                      <input value=""{ dayValue }"" class=""govuk-input govuk-date-input__input govuk-input--width-2 { errorInput }"" id=""day-input-{ Id }"" name=""{ Name }Day"" type=""text"" pattern=""[0-9]*"" inputmode=""numeric"">
                                    </div>
                                  </div>
                                  <div class=""govuk-date-input__item"">
                                    <div class=""govuk-form-group"">
                                      <label class=""govuk-label govuk-date-input__label"" for=""month-input-{ Id }"">
                                        Month
                                      </label>
                                      <input value=""{ monthValue }"" class=""govuk-input govuk-date-input__input govuk-input--width-2 { errorInput }"" id=""month-input-{ Id }"" name=""{ Name }Month"" type=""text"" pattern=""[0-9]*"" inputmode=""numeric"">
                                    </div>
                                  </div>
                                  <div class=""govuk-date-input__item"">
                                    <div class=""govuk-form-group"">
                                      <label class=""govuk-label govuk-date-input__label"" for=""year-input-{ Id }"">
                                        Year
                                      </label>
                                      <input value=""{ yearValue }"" class=""govuk-input govuk-date-input__input govuk-input--width-4 { errorInput }"" id=""year-input-{ Id }"" name=""{ Name }Year"" type=""text"" pattern=""[0-9]*"" inputmode=""numeric"">
                                    </div>
                                  </div>
                                </div>
                              </fieldset>
                            </div>";

            output.Content.SetHtmlContent(template);
        }
    }
}