using KoloDev.GDS.UI.BaseModels.Configuration;

namespace KoloDev.GDS.UI.Configurators.Base
{
    /// <summary>
    /// Base menu configuration
    /// </summary>
    public static class BaseMenuConfiguration
    {
        /// <summary>
        /// Header item
        /// </summary>
        public static class Header
        {
            /// <summary>
            /// Whether this is a user info item
            /// </summary>
            public static bool ShowUserInfo = false;

            /// <summary>
            /// The type of user information to show
            /// </summary>
            public static MenuUserInfoType UserInfoType = MenuUserInfoType.UserName;

            /// <summary>
            /// A list of menu items for the header menu
            /// </summary>
            public static List<Menu> HeaderMenu = new(0);
        }

        /// <summary>
        /// Footer item
        /// </summary>
        public static class Footer
        {
            /// <summary>
            /// A list of menu items for the footer
            /// </summary>
            public static List<Menu> FooterMenu = new(0);
        }
    }
}
