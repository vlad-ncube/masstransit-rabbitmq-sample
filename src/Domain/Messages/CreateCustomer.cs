using System;
using MassTransit;

namespace Domain.Messages
{
    public class CreateCustomer : CorrelatedBy<Guid>
    {
        public Guid CustomerId;
        public string Name;
        public string Email;
        public string Password;
        public Guid CorrelationId { get { return CustomerId; } }
    }
}