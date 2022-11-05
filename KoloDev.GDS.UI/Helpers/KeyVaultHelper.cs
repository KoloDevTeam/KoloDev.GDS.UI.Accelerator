using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace KoloDev.GDS.UI.Helpers
{
    /// <summary>
    /// Key Vault helper
    /// </summary>
    public class KeyVaultHelper
    {
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
        /// <param name="keyVaultName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> GetSecret(string key, string keyVaultName)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (string.IsNullOrEmpty(keyVaultName))
            {
                throw new ArgumentNullException(nameof(keyVaultName));
            }

            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var secret = await GetKeyVaultClient()
                                .GetSecretAsync(kvUri, key);

            return secret.Value;
        }
    }
}