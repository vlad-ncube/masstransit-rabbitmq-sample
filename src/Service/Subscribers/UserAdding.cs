using System;
using Domain.DomainObjects;
using Domain.Messages;
using MassTransit;
using Repositories;

namespace Service.Subscribers
{
	public class UserAdding : Consumes<AddUser>.Context
	{
		public void Consume(IConsumeContext<AddUser> context)
		{
            MongoRepository.AddUser(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = context.Message.FirstName,
                LastName = context.Message.LastName,
                EmailAddress = context.Message.EmailAddress,
                Age = context.Message.Age,
                Location = context.Message.Location
            });

			Console.WriteLine("User {0} has been added", context.Message.FirstName);
		}
	}
}