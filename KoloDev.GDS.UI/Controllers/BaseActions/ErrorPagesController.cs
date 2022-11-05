using KoloDev.GDS.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace KoloDev.GDS.UI.Controllers.BaseActions
{
    /// <summary>
    /// Error pages
    /// </summary>
    public class ErrorPagesController : Controller
    {
        /// <summary>
        /// Generic error page
        /// </summary>
        /// <returns></returns>
        [Title("An error occurred")]
        [HttpGet("Error")]
        public IActionResult GenericError()
        {
            return View();
        }

        /// <summary>
        /// Bad request error page
        /// </summary>
        /// <returns></returns>
        [Title("Bad request")]
        [HttpGet("Error/400")]
        public IActionResult BadRequestError()
        {
            return View();
        }

        /// <summary>
        /// Unauthorised error page
        /// </summary>
        /// <returns></returns>
        [Title("Unauthorised")]
        [HttpGet("Error/401")]
        public IActionResult UnauthorisedError()
        {
            return View();
        }

        /// <summary>
        /// Forbidden error page
        /// </summary>
        /// <returns></returns>
        [Title("Forbidden")]
        [HttpGet("Error/403")]
        public IActionResult ForbiddenError()
        {
            return View();
        }

        /// <summary>
        /// Not found error page
        /// </summary>
        /// <returns></returns>
        [Title("Not found")]
        [HttpGet("Error/404")]
        public IActionResult NotFoundError()
        {
            return View();
        }

        /// <summary>
        /// Method not allowed error page
        /// </summary>
        /// <returns></returns>
        [Title("Method not allowed")]
        [HttpGet("Error/405")]
        public IActionResult MethodNotAllowedError()
        {
            return View();
        }

        /// <summary>
        /// Internal server error page
        /// </summary>
        /// <returns></returns>
        [Title("Server error")]
        [HttpGet("Error/500")]
        public IActionResult InternalServerError()
        {
            return View();
        }

        /// <summary>
        /// Method not implemented error page
        /// </summary>
        /// <returns></returns>
        [Title("Not implemented")]
        [HttpGet("Error/501")]
        public IActionResult NotImplementedError()
        {
            return View();
        }

        /// <summary>
        /// Service unavailable error page
        /// </summary>
        /// <returns></returns>
        [Title("Service unavailable")]
        [HttpGet("Error/503")]
        public IActionResult ServiceUnavailableError()
        {
            return View();
        }
    }
}
