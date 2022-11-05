namespace KoloDev.GDS.UI.BaseModels.Configuration
{
    /// <summary>
    /// Definition of a menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; } = "Not set";
        /// <summary>
        /// Href
        /// </summary>
        public string Href { get; set; } = "";
        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; } = "";
        /// <summary>
        /// Name of controller
        /// </summary>
        public string Controller { get; set; } = "";
        /// <summary>
        /// Name of the action
        /// </summary>
        public string Action { get; set; } = "";
        /// <summary>
        /// Required role to view the menu item
        /// </summary>
        public string[] Roles { get; set; } = Array.Empty<string>();
        /// <summary>
        /// Show only if authenticated
        /// </summary>
        public bool VisibleForAuthenticated { get; set; } = false;
        /// <summary>
        /// The view path of the content (for help pages)
        /// </summary>
        public string ContentViewPath { get; set; } = "";
    }

    /// <summary>
    /// The user info type of an item
    /// </summary>
    public enum MenuUserInfoType
    {
        UserName,
        FirstName,
        FullName,
        Email
    }
}
