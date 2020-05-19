using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFSocialDB.Entities;
using EFSocialDB.Interfaces;

namespace EFSocialDB.EntityRepositories
{
    class UsersRepos : IReposInterface<Users>
    {
        DbContext _context;
        DbSet<Users> _dbSet;

        public UsersRepos(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Users>();
        }

        public IEnumerable<Users> Get()
        {
            return _dbSet.ToList();
        }

        public Users GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(Users item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(Users item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Users item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }

}
