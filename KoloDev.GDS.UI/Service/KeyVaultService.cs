using KoloDev.GDS.UI.BaseModels.Configuration;
using KoloDev.GDS.UI.Service.Interface;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Options;

namespace KoloDev.GDS.UI.Service
{
    public class KeyVaultService : IKeyVault
    {
        private string _keyVaultName;

        public KeyVaultService(IOptions<AppSettings> options)
        {
            _keyVaultName = options.Value.Authentication.KeyVaultName;
        }

        /// <summary>
        /// Get a new key vault client
        /// </summary>
        /// <returns></returns>
        public KeyVaultClient GetKeyVaultClient()
        {
            var tokenProvider = new AzureServiceTokenProvider();
            return new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(tokenProvider.KeyVaultTokenCallback));
        }

        /// <summary>
        /// Get a secret from key vault by name
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> GetSecret(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrEmpty(_keyVaultName))
            {
                throw new ArgumentNullException(nameof(_keyVaultName));
            }

            var kvUri = "https://" + _keyVaultName + ".vault.azure.net";

            var secret = await GetKeyVaultClient()
                                .GetSecretAsync(kvUri, key);

            return secret.Value;
        }
    }
}