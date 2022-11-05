using Microsoft.AspNetCore.Mvc;

namespace KoloDev.GDS.UI.Controllers.BaseActions
{
    /// <summary>
    /// Base controller to make actions available to all controllers
    /// </summary>
    public class BaseController : Controller
    {
        private IConfiguration? _configuration;
        private string _apiBase = String.Empty;

        /// <summary>
        /// Returns IConfiguration
        /// </summary>
        protected IConfiguration Config
        {
            get
            {
                if (_configuration == null && HttpContext != null)
                    _configuration = (IConfiguration)HttpContext.RequestServices.GetService(typeof(IConfiguration));
                return _configuration;
            }
        }

        /// <summary>
        /// Returns API Base address
        /// TODO For API urls, we need key=>val pairs for name => url?
        /// </summary>
        protected string ApiBase
        {
            get
            {
                if (_apiBase == null && HttpContext != null)
                    _apiBase = Config.GetSection("AppOptions:ApiUrl").Value;
                return _apiBase;
            }
        }
    }
}
