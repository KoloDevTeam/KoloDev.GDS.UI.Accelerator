namespace KoloDev.GDS.UI.BaseModels.Configuration
{
    /// <summary>
    /// App settings model
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// User friendly, official name of the service
        /// </summary>
        public string ServiceName { get; set; } = "KoloDev GDS Service";

        /// <summary>
        /// User friendly, official description of the service
        /// </summary>
        public string? ServiceDescription { get; set; } = null;

        /// <summary>
        /// Service URL
        /// </summary>
        public Uri ServiceUrl { get; set; } = new("about:blank");

        /// <summary>
        /// Service phase information
        /// </summary>
        public ServicePhase ServicePhase { get; set; } = new();

        /// <summary>
        /// Service authentication information
        /// </summary>
        public Authentication Authentication { get; set; } = new();
    }

    /// <summary>
    /// Service phase information
    /// </summary>
    public class ServicePhase
    {
        /// <summary>
        /// Show/hide the phase banner
        /// </summary>
        public bool ShowPhaseBanner { get; set; } = false;

        /// <summary>
        /// Current phase of the service
        /// </summary>
        public ServicePhaseType Phase { get; set; } = ServicePhaseType.alpha;

        /// <summary>
        /// Service feedback link
        /// </summary>
        public Uri FeedbackLink { get; set; } = new("about:blank");
    }

    /// <summary>
    /// The current phase of the service
    /// </summary>
    public enum ServicePhaseType
    {
        /// <summary>
        /// Apha phase
        /// </summary>
        alpha,

        /// <summary>
        /// Beta phase
        /// </summary>
        beta,

        /// <summary>
        /// Live phase
        /// </summary>
        live,

        /// <summary>
        /// Retirement phase
        /// </summary>
        retirement
    }

    /// <summary>
    /// Service authentication parameters
    /// </summary>
    public class Authentication
    {
        /// <summary>
        /// The name of the KeyVault you wish to use
        /// </summary>
        public string? KeyVaultName { get; set; } = null;

        /// <summary>
        /// The resource for APIM authentication header
        /// </summary>
        public string? ApimResource { get; set; } = null;

        /// <summary>
        /// Azure B2C settings
        /// </summary>
        public AzureAdB2CSettings AzureAdB2C { get; set; } = new();

        /// <summary>
        /// Azure Active Directory settings
        /// </summary>
        public AzureAdSettings AzureAd { get; set; } = new();
    }

    /// <summary>
    /// Common authenitcation settings
    /// </summary>
    public class CommonAuthenticationSettings
    {
        /// <summary>
        /// Instance
        /// </summary>
        public string? Instance { get; set; } = null;

        /// <summary>
        /// Domain
        /// </summary>
        public string? Domain { get; set; } = null;

        /// <summary>
        /// Tenant ID
        /// </summary>
        public string? TenantId { get; set; } = null;

        /// <summary>
        /// Client ID
        /// </summary>
        public string? ClientId { get; set; } = null;

        /// <summary>
        /// Client Secret
        /// </summary>
        public string? ClientSecret { get; set; } = null;

        /// <summary>
        /// Callback path
        /// </summary>
        public string? CallbackPath { get; set; } = null;

        /// <summary>
        /// Signedout callback path
        /// </summary>
        public string? SignedOutCallbackPath { get; set; } = null;

        /// <summary>
        /// Sign up, sign in policy
        /// </summary>
        public string? SignUpSignInPolicyId { get; set; } = null;

        /// <summary>
        /// Reset password policy
        /// </summary>
        public string? ResetPasswordPolicyId { get; set; } = null;
    }

    /// <summary>
    /// Azure B2C settings
    /// </summary>
    public class AzureAdB2CSettings : CommonAuthenticationSettings
    { }

    /// <summary>
    /// Azure active directory settings
    /// </summary>
    public class AzureAdSettings : CommonAuthenticationSettings
    { }
}