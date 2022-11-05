using KoloDev.GDS.UI.BaseModels.Configuration;
using KoloDev.GDS.UI.Configurators.Base;
using KoloDev.GDS.UI.Filters;
using KoloDev.GDS.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace KoloDev.GDS.UI.Controllers.BaseActions
{
    /// <summary>
    /// Help and information pages
    /// TODO - need to implement cookie accept/decline methods
    /// </summary>
    public class HelpAndInformationController : Controller
    {
        private readonly RazerViewHelper _viewRender;

        /// <summary>
        /// DI
        /// </summary>
        /// <param name="viewRender"></param>
        public HelpAndInformationController(RazerViewHelper viewRender)
        {
            _viewRender = viewRender;
        }

        /// <summary>
        /// Contact us page
        /// </summary>
        /// <returns></returns>
        [Title("Contact us")]
        public IActionResult ContactUs()
        {
            var menuItem = BaseMenuConfiguration.Footer.FooterMenu.FirstOrDefault(x => x.Controller == "HelpAndInformation" && x.Action == "ContactUs");
            if (menuItem != null && !string.IsNullOrEmpty(menuItem.ContentViewPath))
            {
                ViewBag.content = _viewRender.Render(menuItem.ContentViewPath, new Menu());
            }
            return View();
        }

        /// <summary>
        /// Terms and conditions page
        /// </summary>
        /// <returns></returns>
        [Title("Terms and conditions")]
        public IActionResult TermsAndConditions()
        {
            var menuItem = BaseMenuConfiguration.Footer.FooterMenu.FirstOrDefault(x => x.Controller == "HelpAndInformation" && x.Action == "TermsAndConditions");
            if (menuItem != null && !string.IsNullOrEmpty(menuItem.ContentViewPath))
            {
                ViewBag.content = _viewRender.Render(menuItem.ContentViewPath, new Menu());
            }
            return View();
        }

        /// <summary>
        /// Privacy page
        /// </summary>
        /// <returns></returns>
        [Title("Privacy")]
        public IActionResult Privacy()
        {
            var menuItem = BaseMenuConfiguration.Footer.FooterMenu.FirstOrDefault(x => x.Controller == "HelpAndInformation" && x.Action == "Privacy");
            if (menuItem != null && !string.IsNullOrEmpty(menuItem.ContentViewPath))
            {
                ViewBag.content = _viewRender.Render(menuItem.ContentViewPath, new Menu());
            }
            return View();
        }

        /// <summary>
        /// Cookies page
        /// </summary>
        /// <returns></returns>
        [Title("Cookies")]
        public IActionResult Cookies()
        {
            var cookiePreferences = new CookiesPreference();
            var cookie = HttpContext.Request.Cookies.TryGetValue("cookiePreference", out var cookieValue);
            if (cookie is not false && cookieValue is not null)
            {
                cookiePreferences = JsonConvert.DeserializeObject<CookiesPreference>(cookieValue);
            }

            ViewBag.CookiePreferences = cookiePreferences;

            var menuItem = BaseMenuConfiguration.Footer.FooterMenu.FirstOrDefault(x => x.Controller == "HelpAndInformation" && x.Action == "Cookies");
            if (menuItem != null && !string.IsNullOrEmpty(menuItem.ContentViewPath))
            {
                ViewBag.content = _viewRender.Render(menuItem.ContentViewPath, new Menu());
            }

            return View();
        }

        /// <summary>
        /// Page for more information on cookies
        /// </summary>
        /// <returns></returns>
        [Title("Cookies - more information")]
        public IActionResult CookiesMoreInfo()
        {
            // add get cookie for acceptance
            // set view data for acceptance, parse 

            var menuItem = BaseMenuConfiguration.Footer.FooterMenu.FirstOrDefault(x => x.Controller == "HelpAndInformation" && x.Action == "CookiesMoreInfo");
            if (menuItem != null && !string.IsNullOrEmpty(menuItem.ContentViewPath))
            {
                ViewBag.content = _viewRender.Render(menuItem.ContentViewPath, new Menu());
            }
            return View();
        }

        /// <summary>
        /// Submit cookie preferences
        /// </summary>
        /// <param name="preference"></param>
        /// <returns></returns>
        [HttpPost("Cookies/Submit")]
        public IActionResult SubmitCookiePreference([FromBody] CookiesPreference preference)
        {
            var preferenceJson = JsonConvert.SerializeObject(preference);
            HttpContext.Response.Cookies.Append("cookiePreference", preferenceJson);

            return RedirectToAction("Cookies");
        }

        public class CookiesPreference
        {
            public bool Essential { get; set; }
            public bool Analytics { get; set; }
            public bool Functional { get; set; }
        }
    }
}
