using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers.FormComponents
{
    public class GdsTimeTagHelper : TagHelper
    {
        public string Id { get; set; } = "NO-ID-PROVIDED";
        public string Name { get; set; } = "NO-NAME-PROVIDED";
        public string Heading { get; set; } = "Time input";
        public string Hint { get; set; } = "For example, 14 25";
        public DateTime? Value { get; set; } = null;
        public bool IsValid { get; set; } = true;
        public TimeFormat format { get; set; } = TimeFormat.twentyFour;
        public string ValidationMessage { get; set; } = "You must provide a valid time";
        public bool SmallHeading { get; set; } = false;

        public enum TimeFormat
        {
            twentyFour,
            twelve
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var headingSize = "";
            var errorMessage = "";
            var errorOnGroup = "";
            var errorInput = "";
            var hourValue = "";
            var minuteValue = "";
            var isAm = false;
            var isPm = false;
            var amPmInput = "";

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
                hourValue = Value.Value.Hour.ToString();
                minuteValue = Value.Value.Minute.ToString();
            }

            if (format == TimeFormat.twelve)
            {
                if (Value != null)
                {
                    isAm = Value.Value.ToString("tt").ToLower() == "am";
                    isPm = Value.Value.ToString("tt").ToLower() == "pm";
                }
                amPmInput = $@"<div class=""govuk-date-input__item"">
                                    <div class=""govuk-form-group"">
                                      <label class=""govuk-label govuk-date-input__label"" for=""am-pm-input-{ Id }"">
                                        AM or PM
                                      </label>
                                      <select class=""govuk-select govuk-input--width-2 { errorInput }"" id=""am-pm-input-{ Id }"" name=""{ Name }AmPm"">
                                            <option { (isAm ? "selected" : "") } value=""am"">AM</option>
                                            <option { (isPm ? "selected" : "") } value=""pm"">PM</option>
                                      </select>
                                    </div>
                                  </div>";
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
                                      <label class=""govuk-label govuk-date-input__label"" for=""hour-input-{ Id }"">
                                        Hour
                                      </label>
                                      <input value=""{ hourValue }"" class=""govuk-input govuk-date-input__input govuk-input--width-2 { errorInput }"" id=""hour-input-{ Id }"" name=""{ Name }Hour"" type=""text"" pattern=""[0-9]*"" inputmode=""numeric"">
                                    </div>
                                  </div>
                                  <div class=""govuk-date-input__item"">
                                    <div class=""govuk-form-group"">
                                      <label class=""govuk-label govuk-date-input__label"" for=""minute-input-{ Id }"">
                                        Minute
                                      </label>
                                      <input value=""{ minuteValue }"" class=""govuk-input govuk-date-input__input govuk-input--width-2 { errorInput }"" id=""minute-input-{ Id }"" name=""{ Name }Minute"" type=""text"" pattern=""[0-9]*"" inputmode=""numeric"">
                                    </div>
                                  </div>
                                  { amPmInput }
                                </div>
                              </fieldset>
                            </div>";

            output.Content.SetHtmlContent(template);
        }
    }
}