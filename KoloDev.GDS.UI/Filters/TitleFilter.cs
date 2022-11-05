using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KoloDev.GDS.UI.Filters
{
    /// <summary>
    /// Provides the HTML page title
    /// </summary>
    public class Title : Attribute, IActionFilter
    {
        private readonly string _pageTitle;

        /// <summary>
        /// Page title
        /// </summary>
        /// <param name="pageTitle"></param>
        public Title(string pageTitle)
        {
            _pageTitle = pageTitle;
        }

        /// <summary>
        /// Action executing
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context){ }

        /// <summary>
        /// Pass to page via ViewData
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;
            controller.ViewData["PageUserTitle"] = _pageTitle;
        }
    }
}
