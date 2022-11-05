using Flurl;
using Flurl.Http;
using Gridify;

namespace KoloDev.GDS.UI.Extensions
{
    /// <summary>
    /// Flurl extension for Gridify
    /// </summary>
    public static class FlurlGridifyExtension
    {
        /// <summary>
        /// Sorts by a singular field
        /// </summary>
        /// <param name="request"></param>
        /// <param name="field"></param>
        /// <param name="asc"></param>
        /// <param name="nullValueHandling"></param>
        /// <returns></returns>
        public static IFlurlRequest GridifySortBySingle(this IFlurlRequest request, string field, bool asc, NullValueHandling nullValueHandling = NullValueHandling.Remove)
        {
            return request.SetQueryParam("Sort", $"{ field } { (asc ? "asc" : "desc") }", nullValueHandling);
        }

        /// <summary>
        /// Sorts by multiple fields / Custom expression
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expression"></param>
        /// <param name="nullValueHandling"></param>
        /// <returns></returns>
        public static IFlurlRequest GridifySortByCustom(this IFlurlRequest request, string expression, NullValueHandling nullValueHandling = NullValueHandling.Remove)
        {
            return request.SetQueryParam("Sort", expression, nullValueHandling);
        }

        /// <summary>
        /// Filter a requests response data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="expression"></param>
        /// <param name="nullValueHandling"></param>
        /// <returns></returns>
        public static IFlurlRequest GridifyFilter(this IFlurlRequest request, string expression, NullValueHandling nullValueHandling = NullValueHandling.Remove)
        {
            return request.SetQueryParam("Filter", expression, nullValueHandling);
        }

        /// <summary>
        /// Apply a Gridify query object to a request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="query"></param>
        /// <param name="nullValueHandling"></param>
        /// <returns></returns>
        public static IFlurlRequest ApplyGridifyQuery(this IFlurlRequest request, GridifyQuery query,
            NullValueHandling nullValueHandling = NullValueHandling.Remove)
        {
            return request.SetQueryParams(query, nullValueHandling);
        }

    }
}
