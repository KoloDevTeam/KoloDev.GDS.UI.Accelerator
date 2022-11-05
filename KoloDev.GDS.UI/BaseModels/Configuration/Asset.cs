namespace KoloDev.GDS.UI.BaseModels.Configuration
{
    /// <summary>
    /// Definition of an asset
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Location of the asset e.g. wwwroot/css/my-site.min.css
        /// </summary>
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Type of the asset
        /// </summary>
        public AssetType Type { get; set; } = AssetType.JavaScript;

        /// <summary>
        /// Integrity string
        /// </summary>
        public string Integrity { get; set; } = string.Empty;

        /// <summary>
        /// Cross origin type
        /// </summary>
        public CrossOriginType CrossOrigin { get; set; } = CrossOriginType.None;

        /// <summary>
        /// Include a nonce on the element tag
        /// </summary>
        public bool IncludeNonce { get; set; } = false;
    }

    public enum CrossOriginType
    {
        Anonymous,
        UseCredentials,
        None
    }

    /// <summary>
    /// Type of asset
    /// </summary>
    public enum AssetType
    {
        /// <summary>
        /// Javascript file
        /// </summary>
        JavaScript,

        /// <summary>
        /// Stylesheet file
        /// </summary>
        Stylesheet
    }
}