using System;
using Magnum.StateMachine;
using MassTransit;
using MassTransit.Saga;
using Domain.Messages;

namespace Service
{
    public class CustomerSaga : SagaStateMachine<CustomerSaga>, ISaga
    {
        public Guid CorrelationId { get; set; }
        public IServiceBus Bus { get; set; }

        public static State Initial { get; set; }
        public static State Created { get; set; }
        public static State Closed { get; set; }

        public static Event<CreateCustomer> Create { get; set; }
        public static Event<AuthorizeCustomer> Authorize { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        static CustomerSaga()
        {
            Define(() =>
            {
                Initially(
                    When(Create)
                    .Then((saga, message) =>
                    {
                        saga.Name = message.Name;
                        saga.Email = message.Email;
                        saga.Password = message.Password;
                    })
                    .TransitionTo(Created));
                During(Created,
                    When(Authorize));
            });

            Define(() =>
            {
                Correlate(Authorize)
                    .By((saga, message) => saga.CorrelationId == message.CustomerId);
            });

        }
    }
}