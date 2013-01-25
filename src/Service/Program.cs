using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MassTransit;
using MassTransit.Saga;
using Repositories;
using Service.Subscribers;
using Topshelf;

namespace Service
{
    public class Program
    {
		public static WindsorContainer Container;

        public static void Main(string[] args)
        {
			Container = new WindsorContainer();

			//put all our services in this container
			Container.Register(
				AllTypes.FromThisAssembly().BasedOn<IConsumer>(),
				Component.For(typeof(ISagaRepository<>)).ImplementedBy(typeof(InMemorySagaRepository<>)),
				AllTypes.FromThisAssembly().BasedOn<ISaga>(),
				Component.For<IRepository>().ImplementedBy<MongoRepository>()); // TODO: vlad - can we get it from a config?

            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();

				// this should be different from other endpoints in the project
                sbc.ReceiveFrom("rabbitmq://localhost/elevate.service");

				sbc.Subscribe(subs =>
				{
					//tell mastransit to look in the container for classes it's interested in
					subs.LoadFrom(Container);
				});
            });

            var cfg = HostFactory.New(c => {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");

				c.Service<ServiceClass>(a =>
				{
					a.ConstructUsing(service => new ServiceClass());
					a.WhenStarted(o => o.Start());
					a.WhenStopped(o => o.Stop());
				});
            });

            try
            {
                cfg.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}