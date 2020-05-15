using SocialNetwork3.Context;
using SocialNetwork3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NetworkContext())
            {
                var user = new User() { Name = "Ippolit", Age = 44 };
                var photo = new Photo() { Description = "Nature" };
                var comment = new Comment() { Text = "Cool))", PhotoId = 1, UserId = 1 };

                context.Users.Add(user);
                context.Photos.Add(photo);
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }
    }
}
