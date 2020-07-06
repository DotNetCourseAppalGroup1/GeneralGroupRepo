using System;
using System.Collections.Generic;
using ProductDatabase.Entity;

namespace ProductDatabase.Interfaces
{
    public interface IReposInterface<TEntity> where TEntity : EntityBase
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> Get();

        TEntity GetById(int id);
    }
}