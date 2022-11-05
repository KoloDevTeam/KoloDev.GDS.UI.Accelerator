using KoloDev.GDS.UI.BaseModels.Configuration;

namespace KoloDev.GDS.UI.Configurators.Base
{
    /// <summary>
    /// Asset configuration
    /// </summary>
    public static class AssetConfiguration
    {
        /// Required page assets
        public static readonly List<Asset> RequiredAssets = new(0);

        /// User defined JS assets
        public static List<Asset> UserJsAssets = new(0);

        /// User defined CSS assets
        public static List<Asset> UserCssAssets = new(0);

        /// Defines whether the app is using essential cookies
        public static readonly bool EssentialCookies = false;

        /// Defines whether the app is using functional cookies
        public static readonly bool FunctionalCookies = false;

        /// Defines whether hte app is using analytics cookies
        public static readonly bool AnalyticsCookies = false;
    }

    /// <summary>
    /// Shared configuration between Services configuration and App configuration
    /// </summary>
    public static class SharedConfiguration
    {
        /// Enable/Disable response compression
        public static bool UseResponseCompression = false;

        /// Enable/Disable HSTS
        public static bool UseHsts = false;

        /// Enable/Disable auhtentication
        public static bool UseAuthentication = false;
    }

    /// <summary>
    /// Base UI configuration
    /// </summary>
    public class BaseUiConfiguration
    {
        /// Enable/Disable response compression
        public bool UseResponseCompression = true;

        /// Enable/Disable anti forgery
        public bool UseAntiForgery = true;

        /// Enable/Disable HSTS
        public bool UseHsts = true;

        /// Enable/Disable use of application insights
        public bool UseAppInsights = false;

        /// Enable/Disable Rewrite account denied to 401
        public bool RewriteAccountDeniedTo401 = true;

        /// Enable/Disable Security headers
        public bool SecurityHeaders = true;

        /// Enable/Disable Setting of endpoint routing
        public bool SetEndpointRouting = true;

        /// Enable/Disable Redirecting HTTP errors to endpoints (Error/401, Error/400 etc.)
        public bool UserFriendlyErrorRoutes = true;

        /// Set the logging level for application insights
        public LogLevel AppInsightsLoggingLevel = LogLevel.Information;

        /// Authentication configuration
        public Authentication AuthenticationOptions { get; set; } = new Authentication();
    }

    /// <summary>
    /// Base app configuration
    /// </summary>
    public class BaseUiAppConfiguration
    {
        /// Enable/Disable Rewrite account denied to 401
        public bool RewriteAccountDeniedTo401 = true;

        /// Enable/Disable Security headers
        public bool SecurityHeaders = true;

        /// Enable/Disable Setting of endpoint routing
        public bool SetEndpointRouting = true;

        /// Enable/Disable Redirecting HTTP errors to endpoints (Error/401, Error/400 etc.)
        public bool UserFriendlyErrorRoutes = true;
    }
}