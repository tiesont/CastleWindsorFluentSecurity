using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.Windsor;
using FluentSecurity;

namespace CastleWindsorFluentSecurity
{
    public class SecurityProvider
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
            return UserIsAuthenticated() && GetCurrentUserRoles().Intersect(roles) != null;
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
            var ioc = new WindsorContainer();
            var provider = ioc.Install(new AuthenticationProviderInstaller()).Resolve<IAuthenticationProvider>();
            
            provider.SignIn(userName, makePersistent);
        }

        public static void DestroySecuritySession()
        {
            var ioc = new WindsorContainer();
            var provider = ioc.Install(new AuthenticationProviderInstaller()).Resolve<IAuthenticationProvider>();
            
            provider.SignOut();
        }

    }
}