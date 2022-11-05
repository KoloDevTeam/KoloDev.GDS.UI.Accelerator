using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsNotificationTagBlocks
    {
        public IHtmlContent? Title { get; set; }
        public IHtmlContent? Body { get; set; }
    }

    /// <summary>
    /// GDS Notification
    /// https://design-system.service.gov.uk/components/notification-banner/
    /// </summary>
    [RestrictChildren("gds-notification-title", "gds-notification-body")]
    public class GdsNotificationBannerTagHelper : TagHelper
    {

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsPanelTagBlocks();
            context.Items.Add(typeof(GdsNotificationBannerTagHelper), listContext);

            await output.GetChildContentAsync();

            output.TagName = "div";
            output.Attributes.Add("class", "govuk-notification-banner");
            output.Attributes.Add("data-module", "govuk-notification-banner");
            output.Attributes.Add("aria-labelledby", "govuk-notification-banner-title");
            output.Attributes.Add("role", "region");

            if (listContext.Title != null)
            {
                output.Content.AppendHtml(@"<div class=""govuk-notification-banner__header"">
                                                <h2 class=""govuk-notification-banner__title"" id=""govuk-notification-banner-title"">");
                output.Content.AppendHtml(listContext.Title);
                output.Content.AppendHtml(@"</h2></div>");
            }

            if (listContext.Body != null)
            {
                output.Content.AppendHtml(@"<div class=""govuk-notification-banner__content""><p class=""govuk-notification-banner__heading"">");
                output.Content.AppendHtml(listContext.Body);
                output.Content.AppendHtml(@"</p></div>");
            }
        }
    }

    [HtmlTargetElement("gds-notification-title", ParentTag = "gds-notification-banner")]
    public class GdsNotificationTitleTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsPanelTagBlocks)context.Items[typeof(GdsNotificationBannerTagHelper)];
            modalContext.Title = childContent;
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-notification-body", ParentTag = "gds-notification-banner")]
    public class GdsNotificationBodyTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsPanelTagBlocks)context.Items[typeof(GdsNotificationBannerTagHelper)];
            modalContext.Body = childContent;
            output.SuppressOutput();
        }
    }
}
