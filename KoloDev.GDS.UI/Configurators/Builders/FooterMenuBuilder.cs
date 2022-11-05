using KoloDev.GDS.UI.BaseModels.Configuration;

namespace KoloDev.GDS.UI.Configurators.Builders
{
    /// <summary>
    /// Footer menu builder to specify 
    /// what menu items a project needs
    /// </summary>
    public class FooterMenuBuilder
    {
        /// <summary>
        /// Page menu listing
        /// </summary>
        public readonly List<Menu> PageMenu = new(0);

        /// <summary>
        /// Adds the cookie page to the menu
        /// </summary>
        /// <param name="contentViewPath"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithCookies(string? contentViewPath = null)
        {
            PageMenu.Add(new Menu
            {
                Name = "Cookies",
                Controller = "HelpAndInformation",
                Action = "Cookies",
                ContentViewPath = contentViewPath ?? string.Empty
            });
            return this;
        }

        /// <summary>
        /// Adds the contact us page to the menu
        /// </summary>
        /// <param name="contentViewPath"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithContactUs(string? contentViewPath = null)
        {
            PageMenu.Add(new Menu
            {
                Name = "Contact Us",
                Controller = "HelpAndInformation",
                Action = "ContactUs",
                ContentViewPath = contentViewPath ?? string.Empty
            });
            return this;
        }

        /// <summary>
        /// Adds the terms and conditions page to the menu
        /// </summary>
        /// <param name="contentViewPath"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithTermsAndConditions(string? contentViewPath = null)
        {
            PageMenu.Add(new Menu
            {
                Name = "Terms and conditions",
                Controller = "HelpAndInformation",
                Action = "TermsAndConditions",
                ContentViewPath = contentViewPath ?? string.Empty
            });
            return this;
        }

        /// <summary>
        /// Adds the privacy page to the menu
        /// </summary>
        /// <param name="contentViewPath"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithPrivacy(string? contentViewPath = null)
        {
            PageMenu.Add(new Menu
            {
                Name = "Privacy notice",
                Controller = "HelpAndInformation",
                Action = "Privacy",
                ContentViewPath = contentViewPath ?? string.Empty
            });
            return this;
        }

        /// <summary>
        /// Adds a custom item to the menu with a href
        /// </summary>
        /// <param name="name"></param>
        /// <param name="href"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithItem(string name, string href)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Href = href
            });
            return this;
        }

        /// <summary>
        /// Adds a custom item to the menu with a controller and actions
        /// </summary>
        /// <param name="name"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public FooterMenuBuilder WithItem(string name, string controller, string action)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Controller = controller,
                Action = action
            });
            return this;
        }
    }
}
