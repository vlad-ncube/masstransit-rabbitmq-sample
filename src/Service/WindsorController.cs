using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Domain.Messages;

namespace Service
{
	static class WindsorController
	{
		public static WindsorContainer Container;

		static WindsorController()
		{
			Container = new WindsorContainer();
			Container.Register(Component.For<CustomerHasBeenCreated>());
		}
	}
}