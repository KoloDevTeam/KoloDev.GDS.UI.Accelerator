namespace KoloDev.GDS.UI.Service.Interface
{
    public interface IAppAuthentication
    {
        Task<string> GetApimAccessToken();
    }
}