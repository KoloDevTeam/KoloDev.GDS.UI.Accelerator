using KoloDev.GDS.UI.BaseModels.Configuration;
using KoloDev.GDS.UI.Service.Interface;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Options;

namespace KoloDev.GDS.UI.Service
{
    public class AppAuthenticationService : IAppAuthentication
    {
        private string ApimResource { get; }

        public AppAuthenticationService(IOptions<AppSettings> options)
        {
            ApimResource = options.Value.Authentication.ApimResource;
        }

        /// <summary>
        /// Generate an access token for APIM
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetApimAccessToken()
        {
            var provider = new AzureServiceTokenProvider();
            var accessToken = await provider.GetAccessTokenAsync(ApimResource);
            return accessToken;
        }
    }
}