using Flurl.Http;

namespace KoloDev.GDS.UI.Extensions
{
    /// <summary>
    /// Extensions for the FLURL nuget package
    /// </summary>
    public static class FlurlHeaderExtension
    {
        /// <summary>
        /// Adds the header for the APIM subscription key to a request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientOrRequest"></param>
        /// <param name="subscriptionKey"></param>
        /// <returns></returns>
        public static T WithApimSubscriptionKey<T>(this T clientOrRequest, string subscriptionKey) where T : IHttpSettingsContainer
        {
            return clientOrRequest.WithHeader("Ocp-Apim-Subscription-Key", subscriptionKey);
        }

        /// <summary>
        /// Adds the header for API version to a request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="clientOrRequest"></param>
        /// <param name="apiVersionNumber"></param>
        /// <returns></returns>
        public static T WithApiVersion<T>(this T clientOrRequest, int apiVersionNumber) where T : IHttpSettingsContainer
        {
            return clientOrRequest.WithHeader("x-api-version", apiVersionNumber);
        }
    }
}