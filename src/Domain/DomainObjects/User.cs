using System;

namespace Domain.DomainObjects
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public byte Age { get; set; }
        public string Location { get; set; }
    }
}