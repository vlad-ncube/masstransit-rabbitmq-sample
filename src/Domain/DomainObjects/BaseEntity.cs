using System;

namespace Domain.DomainObjects
{
    // TODO: vlad - can we refuse interface IEntity and use the abstract class only?
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}