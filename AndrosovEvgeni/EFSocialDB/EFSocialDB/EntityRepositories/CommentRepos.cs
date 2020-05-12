using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFSocialDB.Entities;
using EFSocialDB.Interfaces;

namespace EFSocialDB.EntityRepositories
{
    class CommentRepos : IReposInterface<Comments>
    {
        DbContext _context;
        DbSet<Comments> _dbSet;

        public CommentRepos(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Comments>();
        }

        public IEnumerable<Comments> Get() => _dbSet.ToList();

        public Comments GetById(int id) => _dbSet.Find(id);

            public void Add(Comments item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(Comments item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(Comments item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }

}