using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsMessagingTagHelper
    {
        public class GdsDetailsContext
        {
            public List<IHtmlContent>? Messages { get; set; } = null;
        }

        [HtmlTargetElement("gds-messages")]
        [RestrictChildren("gds-message")]
        public class GdsDetailsTagHelper : TagHelper
        {
            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                var listContext = new GdsDetailsContext();
                context.Items.Add(typeof(GdsDetailsTagHelper), listContext);

                await output.GetChildContentAsync();

                output.TagName = "details";
                output.Attributes.Add("class", "govuk-details");
                output.Attributes.Add("data-module", "govuk-details");
                
                if (listContext.Messages != null)
                {
                    output.Content.AppendHtml(@"<div class=""govuk-details__text"">");
                    foreach (var contextMessage in listContext.Messages)
                    {
                        output.Content.AppendHtml(contextMessage);
                    }
                    output.Content.AppendHtml("</div>");
                }
            }
        }
        
        [HtmlTargetElement("gds-message", ParentTag = "gds-messages")]
        public class GdsMessageTagHelper : TagHelper
        {
            public bool IsReceived { get; set; }
            public DateTime SentOn { get; set; }
            public string Message { get; set; }
            public string User { get; set; }

            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                var childContent = await output.GetChildContentAsync();
                var modalContext = (GdsDetailsContext)context.Items[typeof(GdsDetailsTagHelper)];
                
                var html = $@"<div class=""moj-message-item { (IsReceived ? "moj-message-item--received" : "moj-message-item--sent") }"">
                              <div class=""moj-message-item__text moj-message-item__text--sent"">
                                    { Message }
                              </div>
                              <div class=""moj-message-item__meta"">
                                <span class=""moj-message-item__meta--sender"">{ User }</span> at 
                                <time class=""moj-message-item__meta--timestamp"" datetime=""{ SentOn.ToString("dd/MM/yyyy HH:mm") }"">{ SentOn.ToString("dd/MM/yyyy HH:mm") }</time>
                              </div>
                            </div>";

                output.SuppressOutput();
            }
        }

        [HtmlTargetElement("gds-message-date-heading", ParentTag = "gds-messages")]
        public class GdsMessageDateHeadingTagHelper : TagHelper
        {
            public DateTime Date { get; set; }

            public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
            {
                var modalContext = (GdsDetailsContext)context.Items[typeof(GdsDetailsTagHelper)];

                output.TagName = "time";
                output.Attributes.Add("datetime", Date.ToString("dd/MM/yyyy HH:mm"));
                output.Attributes.Add("class", "gds-message-list__date");
                output.Content.SetContent(Date.ToString("dd/MM/yyyy HH:mm"));

                modalContext.Messages.Add(output);
                output.SuppressOutput();
            }
        }
    }
}
