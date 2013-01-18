using Domain.Messages;
using MassTransit;

namespace Customers
{
	public class CustomerAuthorizationService : Consumes<CustomerHasBeenCreated>.Context
	{
		public void Consume(IConsumeContext<CustomerHasBeenCreated> context)
		{
			Bus.Instance.Publish(new AuthorizeCustomer { CustomerId = context.Message.CustomerId });
		}
	}
}