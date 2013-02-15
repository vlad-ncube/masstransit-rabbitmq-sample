using System;
using Castle.Windsor;
using Domain.DomainObjects;
using Domain.Messages;
using MassTransit;
using MasstransitSpike.Core.Repositories;

namespace Service.Subscribers
{
	public class UserAdding : Consumes<AddUser>.Context
	{
		public void Consume(IConsumeContext<AddUser> context)
		{
            IUserRepository repository = Program.Container.Resolve<IUserRepository>();

            repository.Add(new User
            {
                Id = Guid.NewGuid(),
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