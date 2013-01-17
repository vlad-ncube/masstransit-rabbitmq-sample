using System;
using Domain.Messages;
using MassTransit;

namespace Service
{
    public class CustomerActivationService : Consumes<ActivateCustomerCommand>.Context
    {
        public void Start()
        {
            Console.WriteLine("Starting....");
        }

        public void Stop()
        {

            Console.WriteLine("Stopping....");
        }

        public void ParseCv(string name)
        {
            Console.WriteLine(name);
        }

	    public void Consume(IConsumeContext<ActivateCustomerCommand> context)
	    {
		    ParseCv(context.Message.S3Key);
	    }
    }
}
