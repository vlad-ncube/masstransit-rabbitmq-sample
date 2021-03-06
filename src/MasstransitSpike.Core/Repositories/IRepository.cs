﻿using Domain.DomainObjects;

namespace MasstransitSpike.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        void Add(TEntity enity);

        //TEntity Get(Guid id);

        //void Update(TEntity entity);

        //void Delete(Guid id);

        void DeleteAll();
    }
}