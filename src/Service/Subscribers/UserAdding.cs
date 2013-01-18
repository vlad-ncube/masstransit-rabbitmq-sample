using System;
using Domain.Messages;
using MassTransit;

namespace Service.Subscribers
{
	public class UserAdding : Consumes<AddUser>.Context
	{
		public void Consume(IConsumeContext<AddUser> context)
		{
			Console.WriteLine("User {0} has been added", context.Message.FirstName);
		}
	}
}