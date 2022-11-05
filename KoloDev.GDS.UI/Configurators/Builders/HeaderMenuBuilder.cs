using KoloDev.GDS.UI.BaseModels.Configuration;

namespace KoloDev.GDS.UI.Configurators.Builders
{
    /// <summary>
    /// Header menu builder to allow specifying of the header menu
    /// </summary>
    public class HeaderMenuBuilder
    {
        /// <summary>
        /// Page menu listing
        /// </summary>
        public readonly List<Menu> PageMenu = new(0);

        /// <summary>
        /// Adds a custom item to the menu with a href
        /// </summary>
        /// <param name="name"></param>
        /// <param name="href"></param>
        /// <param name="visibleWhenAuthenticated"></param>
        /// <returns></returns>
        public HeaderMenuBuilder WithItem(string name, string href, bool visibleWhenAuthenticated = false)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Href = href,
                VisibleForAuthenticated = visibleWhenAuthenticated
            });
            return this;
        }

        /// <summary>
        /// Adds a custom item to the menu with a controller and action
        /// </summary>
        /// <param name="name"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="visibleWhenAuthenticated"></param>
        /// <returns></returns>
        public HeaderMenuBuilder WithItem(string name, string controller, string action, bool visibleWhenAuthenticated = false)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Controller = controller,
                Action = action,
                VisibleForAuthenticated = visibleWhenAuthenticated
            });
            return this;
        }

        /// <summary>
        /// Adds a custom item to the menu with a href and a list of roles required to view the item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="href"></param>
        /// <param name="requireRoles"></param>
        /// <param name="visibleWhenAuthenticated"></param>
        /// <returns></returns>
        public HeaderMenuBuilder WithItem(string name, string href, string[] requireRoles, bool visibleWhenAuthenticated = false)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Href = href,
                Roles = requireRoles,
                VisibleForAuthenticated = visibleWhenAuthenticated
            });
            return this;
        }

        /// <summary>
        /// Adds a custom item to the menu with a controller, action and a list of roles required to view the item
        /// </summary>
        /// <param name="name"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="requireRoles"></param>
        /// <param name="visibleWhenAuthenticated"></param>
        /// <returns></returns>
        public HeaderMenuBuilder WithItem(string name, string controller, string action, string[] requireRoles, bool visibleWhenAuthenticated = false)
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Controller = controller,
                Action = action,
                Roles = requireRoles,
                VisibleForAuthenticated = visibleWhenAuthenticated
            });
            return this;
        }

        /// <summary>
        /// Add a signout link for logged in
        /// </summary>
        /// <param name="name"></param>
        /// <param name="area"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public HeaderMenuBuilder WithSignoutLink(string name = "Sign out", string area = "MicrosoftIdentity", string controller = "Account", string action = "SignOut")
        {
            PageMenu.Add(new Menu
            {
                Name = name,
                Area = area,
                Controller = controller,
                Action = action,
                VisibleForAuthenticated = true
            });
            return this;
        }
    }
}
