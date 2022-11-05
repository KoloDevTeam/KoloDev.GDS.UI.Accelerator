using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KoloDev.GDS.UI.Filters
{
    /// <summary>
    /// Provide the user with a GDS back link on page
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class BackLink : Attribute, IActionFilter
    {
        private readonly string _controller = String.Empty;
        private readonly string _action = String.Empty;
        private readonly string _href = String.Empty;

        /// <summary>
        /// Back link via href
        /// </summary>
        /// <param name="href"></param>
        public BackLink(string href)
        {
            _href = href;
        }

        /// <summary>
        /// Back link via controller and action
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        public BackLink(string controller, string action)
        {
            _controller = controller;
            _action = action;
        }

        /// <summary>
        /// Action executed
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context) { }

        /// <summary>
        /// Executing, provide params to the ViewData
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;
            controller.ViewData["BackLinkVisible"] = true;
            controller.ViewData["BackLinkController"] = _controller;
            controller.ViewData["BackLinkAction"] = _action;
            controller.ViewData["BackLinkHref"] = _href;
        }
    }
}
