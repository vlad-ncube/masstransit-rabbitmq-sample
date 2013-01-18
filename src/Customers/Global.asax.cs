using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Customers.App_Start;
using MassTransit;

namespace Customers
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			ConfigureBus();
		}

		void ConfigureBus()
		{
			WindsorContainer container = new WindsorContainer();
			//put all our services in this container
			container.Register(AllTypes.FromThisAssembly().BasedOn<IConsumer>());

			Bus.Initialize(sbc =>
			{
				sbc.UseRabbitMq();
				// this should be different from other endpoints in the project
				sbc.ReceiveFrom("rabbitmq://localhost/sample.web");
				sbc.Subscribe(subs =>
				{
					subs.LoadFrom(container);
				});
			});
		}
	}
}