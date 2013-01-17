using System;

namespace Domain.Messages
{
    public class ActivateCustomerCommand
    {
        public string S3Key { get; set; }
        public Guid ContractorId { get; set; }
    }
}