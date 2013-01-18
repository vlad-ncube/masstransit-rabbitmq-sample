using System;
using Domain.Messages;
using MassTransit;

namespace Service
{
    public class CustomerActivationService : Consumes<ActivateCustomerCommand>.Context
    {
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