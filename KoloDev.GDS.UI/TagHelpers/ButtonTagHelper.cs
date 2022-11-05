using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsButtonGroupContext
    {
        public List<IHtmlContent> Button { get; set; } = new(0);
    }

    [RestrictChildren("button", "a")]
    public class ButtonGroupTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsButtonGroupContext();
            context.Items.Add(typeof(ButtonGroupTagHelper), listContext);

            output.TagName = "div";
            output.Attributes.Add("class", "govuk-button-group");

            foreach (var item in listContext.Button)
            {
                output.Content.AppendHtml(item);
            }

            await output.GetChildContentAsync();
        }
    }

    public class ButtonTagHelper : TagHelper
    {
        public ButtonType GdsType { get; set; } = ButtonType.primary;
        public bool IsDisabled { get; set; } = false;
        public bool IsSubmit { get; set; } = false;
        public bool IsLink { get; set; } = false;

        public enum ButtonType
        {
            primary, secondary, warning, start
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();
            List<string> classNames = new(1) { "govuk-button" };

            if (!IsLink)
            {
                output.TagName = "button";
            }
            else
            {
                output.TagName = "a";
            }

            output.Attributes.Add("role", "button");
            output.Attributes.Add("data-module", "govuk-button");

            switch (GdsType)
            {
                case ButtonType.primary:
                    output.Content.SetHtmlContent(content.GetContent());
                    break;

                case ButtonType.secondary:
                    classNames.Add("govuk-button--secondary");
                    output.Content.SetHtmlContent(content.GetContent());
                    break;

                case ButtonType.warning:
                    classNames.Add("govuk-button--warning");
                    output.Content.SetHtmlContent(content.GetContent());
                    break;

                case ButtonType.start:
                    classNames.Add("govuk-button--start");
                    var startNowContent =
                        $@"{content.GetContent()} <svg class=""govuk-button__start-icon"" xmlns=""http://www.w3.org/2000/svg"" width=""17.5"" height=""19"" viewBox=""0 0 33 40"" aria-hidden=""true"" focusable=""false"">
                            <path fill=""currentColor"" d=""M0 0h13l20 20-20 20H0l20-20z"" />
                        </svg>";
                    output.Content.SetHtmlContent(startNowContent);
                    break;
            }

            if (IsDisabled)
            {
                output.Attributes.Add("aria-disabled", "true");
                output.Attributes.Add("disabled", "disabled");
                classNames.Add("govuk-button--disabled");
            }
            if (IsSubmit && !IsLink)
            {
                output.Attributes.Add("type", "submit");
            }

            output.Attributes.Add("class", string.Join(" ", classNames));
        }
    }
}