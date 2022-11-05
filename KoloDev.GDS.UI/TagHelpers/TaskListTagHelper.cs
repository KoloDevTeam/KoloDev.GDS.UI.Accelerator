using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KoloDev.GDS.UI.TagHelpers
{
    /// <summary>
    /// Task list pattern
    /// https://design-system.service.gov.uk/patterns/task-list-pages/
    /// </summary>
    public class GdsTaskListContext
    {
        public List<string> TaskSections { get; set; } = new(0);
        public int Total = 0;
        public int CompletedSections = 0;
    }

    [RestrictChildren("gds-tasklist-section")]
    [HtmlTargetElement("gds-tasklist")]
    public class GdsTaskListTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var listContext = new GdsTaskListContext();
            context.Items.Add(typeof(GdsTaskListTagHelper), listContext);

            await output.GetChildContentAsync();

            var tasksComplete = "incomplete";
            if (listContext.Total == listContext.CompletedSections)
            {
                tasksComplete = "complete";
            }

            output.Content.AppendHtml($@"<h2 class=""govuk-heading-s govuk-!-margin-bottom-2"">Tasks { tasksComplete }</h2>
                                            <p class=""govuk-body govuk-!-margin-bottom-7"">You have completed { listContext.CompletedSections } of { listContext.Total } tasks.</p>
                                                <ol class=""app-task-list"">");

            foreach (var taskSection in listContext.TaskSections)
            {
                output.Content.AppendHtml(taskSection);
            }

            output.Content.AppendHtml(@"</ol>");
        }
    }

    [RestrictChildren("gds-tasklist-task")]
    [HtmlTargetElement("gds-tasklist-section", ParentTag = "gds-tasklist")]
    public class GdsTaskListSectionTagHelper : TagHelper
    {
        public string SectionName { get; set; } = string.Empty;
        public string SectionNumber { get; set; } = string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var modalContext = (GdsTaskListContext)context.Items[typeof(GdsTaskListTagHelper)];

            output.Content.AppendHtml($@"<li>
                                  <h2 class=""app-task-list__section"">
                                    <span class=""app-task-list__section-number"">{ SectionNumber }. </span> { SectionName }
                                  </h2>
                                  <ul class=""app-task-list__items"">");
            output.Content.AppendHtml(childContent);
            output.Content.AppendHtml(@"</ul></li>");

            modalContext.TaskSections.Add(output.Content.GetContent());
            output.SuppressOutput();
        }
    }

    [HtmlTargetElement("gds-tasklist-task", ParentTag = "gds-tasklist-section")]
    public class GdsTaskListTaskTagHelper : TagHelper
    {
        public GdsTaskState TaskState { get; set; } = GdsTaskState.NotStarted;

        public enum GdsTaskState
        {
            NotStarted,
            CannotStartYet,
            InProgress,
            Completed
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            var taskContext = (GdsTaskListContext)context.Items[typeof(GdsTaskListTagHelper)];

            var tagClass = "";
            var tagText = "Not started";

            taskContext.Total++;
            switch (TaskState)
            {
                case GdsTaskState.NotStarted:
                    tagClass = "govuk-tag--grey";
                    break;

                case GdsTaskState.CannotStartYet:
                    tagClass = "govuk-tag--grey";
                    tagText = "Cannot start yet";
                    break;

                case GdsTaskState.InProgress:
                    tagClass = "govuk-tag--blue";
                    tagText = "In progress";
                    break;

                case GdsTaskState.Completed:
                    tagText = "Completed";
                    taskContext.CompletedSections++;
                    break;
            }

            output.Content.AppendHtml(@"<li class=""app-task-list__item"">
                            <span class=""app-task-list__task-name"">");

            output.Content.AppendHtml(childContent);

            output.Content.AppendHtml(@$"</span>
                                        <strong class=""govuk-tag { tagClass } app-task-list__tag"">{ tagText }</strong>
                                    </li>");

            //taskContext.se.Add(output.Content);
            //output.SuppressOutput();
        }
    }
}