using System;
using System.Collections.Generic;
using EFSocialDB.Entities;

namespace EFSocialDB.Interfaces
{
    public interface IReposInterface<TEntity> where TEntity : EntityModel
    {
        void Add(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> Get();

        TEntity GetById(int id);
    }

    public interface IGenericRepository<TEntity> where TEntity
        : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }

}
