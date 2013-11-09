using System.Linq;
using System.Reflection;

using AutoMapper;

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CastleWindsorFluentSecurity
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Mapper.Initialize(m => m.ConstructServicesUsing(container.Resolve));

            container.Register(Types.FromAssembly(Assembly.GetExecutingAssembly()).BasedOn<IValueResolver>());
            container.Register(Types.FromThisAssembly().BasedOn<Profile>().WithServiceBase());
            var profiles = container.ResolveAll<Profile>();
            profiles.ToList().ForEach(p => Mapper.AddProfile(p));

            container.Register(Component.For<IMappingEngine>().Instance(Mapper.Engine));
        }
    }
}