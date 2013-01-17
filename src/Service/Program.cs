using System;
using MassTransit;
using MassTransit.Saga;
using Topshelf;


namespace Service
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.UseRabbitMqRouting();
				// this should be different from other endpoints in the project
                sbc.ReceiveFrom("rabbitmq://localhost/elevate.service");
				sbc.Subscribe(subs =>
				{
					subs.Saga(new InMemorySagaRepository<CustomerSaga>())
						.Permanent();
				});
            });

            var cfg = HostFactory.New(c => {

                c.SetServiceName("ElevateServices");
                c.SetDisplayName("ElevateServices");
                c.SetDescription("ElevateServices");

                //c.BeforeStartingServices(s => {});

                c.Service<CvParserService>(a =>
                {
                    a.ConstructUsing(service => new CvParserService());
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
