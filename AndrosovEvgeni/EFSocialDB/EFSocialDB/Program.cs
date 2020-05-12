using System;
using EFSocialDB.Entities;
using EFSocialDB.EntityRepositories;

namespace EFSocialDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DatabaseContext.DatabaseContext db = new DatabaseContext.DatabaseContext())
            {
                UsersRepos userRepos = new UsersRepos(db);
                var users = db.Users;

                foreach (Users u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}");
                }

                var photos = db.Photos;

                foreach (Photos photo in photos)
                {
                    Console.WriteLine($"Photo id: {photo.Id} by user {photo.UserId}.{userRepos.GetById(photo.UserId).Name}");
                }
            }
            Console.Read();
        }
    }
}
