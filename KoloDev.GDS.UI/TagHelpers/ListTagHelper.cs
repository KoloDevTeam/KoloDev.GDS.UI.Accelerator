using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    public class GdsListContext
    {
        public List<IHtmlContent> ListItem { get; set; } = new(0);
    }

    /// <summary>
    /// GDS List
    /// https://design-system.service.gov.uk/styles/typography/#lists
    /// </summary>
    [RestrictChildren("gds-list-item")]
    public class GdsListTagHelper : TagHelper
    {
        public ListType Type { get; set; } = ListType.bullet;
        public bool ExtraSpacing { get; set; } = false;

        public enum ListType
        {
            none,
            bullet,
            number
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsListContext();
            context.Items.Add(typeof(GdsListTagHelper), listContext);

            await output.GetChildContentAsync();

            var listTypeClass = "";
            switch (Type)
            {
                case ListType.number:
                    listTypeClass = "govuk-list govuk-list--number";
                    break;
                case ListType.bullet:
                    listTypeClass = "govuk-list govuk-list--bullet";
                    break;
                case ListType.none:
                    listTypeClass = "govuk-list";
                    break;
            }

            if (ExtraSpacing)
            {
                listTypeClass += " govuk-list--spaced";
            }

            output.Content.AppendHtml($@"<ul class=""{ listTypeClass }"">");

            foreach (var item in listContext.ListItem)
            {
                output.Content.AppendHtml("<li>");
                output.Content.AppendHtml(item);
                output.Content.AppendHtml("</li>");
            }

            output.Content.AppendHtml("</ul>");
        }
    }

    [HtmlTargetElement("gds-list-item", ParentTag = "gds-list")]
    public class GdsListItemTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsListContext)context.Items[typeof(GdsListTagHelper)];
            modalContext.ListItem.Add(childContent);
            output.SuppressOutput();
        }
    }
}
