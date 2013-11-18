using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentSecurity;

namespace CastleWindsorFluentSecurity
{
    public class SecurityProvider : IDisposable
    {
        public static bool UserIsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool ActionIsAllowedForUser(string controllerName, string actionName)
        {
            var configuration = SecurityConfiguration.Current;
            var policyContainer = configuration.PolicyContainers.GetContainerFor(controllerName, actionName);
            if (policyContainer != null)
            {
                var context = SecurityContext.Current;
                var results = policyContainer.EnforcePolicies(context);
                return results.All(x => x.ViolationOccured == false);
            }

            // WARNING: Assuming (for now) that no policies means no restrictions
            return true;
        }

        public static bool HasAnyRole(params string[] roles)
        {
            var context = SecurityContext.Current;

            return context.CurrentUserIsAuthenticated() && context.CurrentUserRoles().Intersect(roles) != null;
        }

        public static IEnumerable<string> GetCurrentUserRoles()
        {
            // TODO: Add service class to query for user's roles
            return new string[] { "Super User" };
        }

        public static bool UserCredentialsAreValid(string userName, string password)
        {
            // TODO: Add service class to validate user's credentials
            return true;
        }

        public static void CreateSecuritySession(string userName, bool makePersistent = false)
        {
            using (var provider = AuthenticationProviderFactory<FormsAuthenticationProvider>.Create())
            {
                provider.SignIn(userName, makePersistent);
            }
        }

        public static void DestroySecuritySession()
        {
            using (var provider = AuthenticationProviderFactory<FormsAuthenticationProvider>.Create())
            {
                provider.SignOut();
            }
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposeAll"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposeAll)
        {
            if (disposeAll)
            {
                // TODO: delete/dispose any non-local resources
            }
        }

    }
}