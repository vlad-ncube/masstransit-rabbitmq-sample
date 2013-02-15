using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using MasstransitSpike.Core.Repositories;

namespace Repositories.MySqlFake
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly().BasedOn(typeof(IRepository<>)).WithServiceDefaultInterfaces());
        }
    }
}