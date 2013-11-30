using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleWindsorFluentSecurity
{
    public class AuthenticationProviderInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IAuthenticationProvider>()
                .ImplementedBy<FormsAuthenticationProvider>()
                .LifestyleTransient());
        }
    }
}