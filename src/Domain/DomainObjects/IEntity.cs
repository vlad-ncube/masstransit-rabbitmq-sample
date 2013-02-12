using System;

namespace Domain.DomainObjects
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}