using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KoloDev.GDS.UI.Filters
{
    /// <summary>
    /// Enable GDS JS on page
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UseGdsJavascipt : Attribute, IActionFilter
    {
        /// <summary>
        /// Action executed
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context) { }

        /// <summary>
        /// Pass value to ViewData
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!(context.Controller is Controller controller)) return;
            controller.ViewData["UseGdsJavascript"] = true;
        }
    }
}
