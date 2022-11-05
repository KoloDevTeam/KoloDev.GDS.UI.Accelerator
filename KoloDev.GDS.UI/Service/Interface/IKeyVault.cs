using Microsoft.Azure.KeyVault;

namespace KoloDev.GDS.UI.Service.Interface
{
    public interface IKeyVault
    {
        KeyVaultClient GetKeyVaultClient();

        Task<string> GetSecret(string key);
    }
}