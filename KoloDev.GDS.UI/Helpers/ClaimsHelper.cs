using System.Security.Claims;
using System.Security.Principal;

namespace KoloDev.GDS.UI.Helpers
{
    /// <summary>
    /// Claims helpers
    /// </summary>
    public static class ClaimsHelper
    {
        /// <summary>
        /// Get claim by string name
        /// </summary>
        /// <param name="user"></param>
        /// <param name="claimName"></param>
        /// <returns></returns>
        public static string? GetClaim(this ClaimsPrincipal user, string claimName)
        {
            return user?.Claims.FirstOrDefault(c => c.Type == claimName) != null ? user.Claims.FirstOrDefault(c => c.Type == claimName)?.Value : "";
        }

        /// <summary>
        /// Check the user is in a list of roles
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
        {
            return roles.Any(principal.IsInRole);
        }
    }
}
