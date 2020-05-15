using SocialNetwork3.Context;
using SocialNetwork3.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.GenericRepository
{
    //public class GenericRepo<TEntity> : IGenericRepository<TEntity> where TEntity : class
    //{
    //    private readonly NetworkContext _networkContext;

    //    public GenericRepo(NetworkContext networkContext)
    //    {
    //        _networkContext = networkContext;
    //    }

    //    public async Task Create(TEntity entity)
    //    {
    //        _networkContext.Set<TEntity>().Add(entity);
    //        await _networkContext.SaveChangesAsync();
    //    }

    //    public async Task Delete(int id)
    //    {
    //        var entity = await GetById(id);
    //        _networkContext.Set<TEntity>().Remove(entity);
    //        await _networkContext.SaveChangesAsync();
    //    }

    //    public IQueryable<TEntity> GetAll()
    //    {
    //        return _networkContext.Set<TEntity>().AsNoTracking();
    //    }

    //    public async Task<TEntity> GetById(int id)
    //    {
    //        return await _networkContext.Set<TEntity>()
    //            .AsNoTracking()
    //           .FirstOrDefaultAsync();
    //    }

    //    public async Task Update(int id, TEntity entity)
    //    {
    //        _networkContext.Entry(entity).State = EntityState.Modified;
    //        await _networkContext.SaveChangesAsync();
    //    }
    //}
}
