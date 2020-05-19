using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFSocialDB.Entities;
using EFSocialDB.Interfaces;

namespace EFSocialDB.EntityRepositories
{
    class PhotosRepos : IReposInterface<Photos>
    {
        DbContext _context;
        DbSet<Photos> _dbSet;

        public PhotosRepos(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Photos>();
        }

        public IEnumerable<Photos> Get()
        {
            return _dbSet.ToList();
        }

        public Photos GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(Photos item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(Photos item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Photos item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }

}