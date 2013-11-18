using System.Web;

using CastleWindsorFluentSecurity.Controllers;

using FluentSecurity;

namespace CastleWindsorFluentSecurity
{
    public class SecurityConfig
    {
        public static void RegisterSecurityRules()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                /* 
                 * Remove this setting to use the default behavior of Fluent Security, 
                 * or modify the internals of Core/Policies/DenyAccessPolicyViolationHandler.cs to
                 * define your desired behavior.
                 */
                configuration.DefaultPolicyViolationHandlerIs(() => new DenyAccessPolicyViolationHandler());

                /* 
                 * Let Fluent Security know how to get the authentication status of the current user 
                 */
                configuration.GetAuthenticationStatusFrom(() => SecurityProvider.UserIsAuthenticated());

                /* 
                 * Let Fluent Security know how to get the roles for the current user.
                 * 
                 * Complete Core/Policies/DenyAccessPolicyViolationHandler.cs to provide access to your 
                 * credentials store
                 */
                configuration.GetRolesFrom(() => SecurityProvider.GetCurrentUserRoles());

                // Secure all action methods of all controllers
                configuration.ForAllControllers().DenyAnonymousAccess();

                /* 
                 * This is where you set up the policies you want Fluent Security to enforce: 
                 */

                configuration.For<ErrorsController>().Ignore();
                configuration.For<Elmah.Mvc.ElmahController>().RequireAnyRole("Super User");

                /*
                 * This is an example of a custom policy. Using the policy suggested here: http://www.fluentsecurity.net/wiki/Policies,
                 * we can make the ELMAH controller available only when running under localhost. 
                 * 
                 * See Core/Policies/LocalOnlyPolicy.cs
                 */
                configuration.For<Elmah.Mvc.ElmahController>().AddPolicy<LocalOnlyPolicy>();

                configuration.For<HomeController>().Ignore();

                configuration.For<HomeController>(ac => ac.Restricted()).RequireAnyRole("Super User");

                configuration.For<AccountController>(ac => ac.LogIn(string.Empty)).Ignore();
                configuration.For<AccountController>(ac => ac.ResetPassword()).Ignore();
                configuration.For<AccountController>(ac => ac.UpdatePassword(string.Empty, string.Empty)).Ignore();

            });
        }
    }
}