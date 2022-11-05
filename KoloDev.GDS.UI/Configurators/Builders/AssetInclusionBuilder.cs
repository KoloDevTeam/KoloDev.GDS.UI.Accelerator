using KoloDev.GDS.UI.BaseModels.Configuration;
using KoloDev.GDS.UI.Configurators.Base;

namespace KoloDev.GDS.UI.Configurators.Builders
{
    /// <summary>
    /// Asset inclusion builder to allow inclusion of 
    /// scripts and stylsheets in to the page layout
    /// </summary>
    public class AssetInclusionBuilder
    {
        /// <summary>
        /// Stylesheet locations
        /// </summary>
        public readonly List<Asset> StyleSheets = new(0);
        /// <summary>
        /// Javascript locations
        /// </summary>
        public readonly List<Asset> JavaScripts = new(0);

        /// <summary>
        /// Adds a script to the list of assets
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public AssetInclusionBuilder WithScript(string location)
        {
            JavaScripts.Add(new Asset
            {
                Location = location,
                Type = AssetType.JavaScript
            });
            return this;
        }

        /// <summary>
        /// Adds a script to the list of assets
        /// </summary>
        /// <param name="location"></param>
        /// <param name="useNonce"></param>
        /// <returns></returns>
        public AssetInclusionBuilder WithScript(string location, bool useNonce)
        {
            JavaScripts.Add(new Asset
            {
                Location = location,
                Type = AssetType.JavaScript,
                IncludeNonce = useNonce
            });
            return this;
        }

        /// <summary>
        /// Adds a stylesheet to the list of assets
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public AssetInclusionBuilder WithStyleSheet(string location)
        {
            StyleSheets.Add(new Asset
            {
                Location = location,
                Type = AssetType.Stylesheet
            });
            return this;
        }

        /// <summary>
        /// Sets the asset configuration
        /// </summary>
        public void Build()
        {
            AssetConfiguration.UserJsAssets = JavaScripts;
            AssetConfiguration.UserCssAssets = StyleSheets;
        }
    }
}
