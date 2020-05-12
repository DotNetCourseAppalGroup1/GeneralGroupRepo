using System.Collections.Generic;
using System.Data.Entity;
using EFSocialDB.Entities;

namespace DatabaseContext
{
    class SocialDbInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            List<Users> users = new List<Users>()
            {
                new Users() { Name = "Tom"},
                new Users() { Name = "Bob"},
                new Users() { Name = "Eugene"},
                new Users() { Name = "Alexey"},
                new Users() { Name = "Alexandr"}
            };
            db.Users.AddRange(users);

            List<Photos> photos = new List<Photos>()
            {
                new Photos() {PhotoDescription = "MyPhoto", UserId = 1},
                new Photos() {PhotoDescription = "MyPhoto2", UserId = 2},
                new Photos() {PhotoDescription = "MyPhoto12", UserId = 1},
                new Photos() {PhotoDescription = "MyPhoto3", UserId = 3}
            };
            db.Photos.AddRange(photos);

            List<Comments> comments = new List<Comments>()
            {
                new Comments() {PhotoId = 1,CommentText = "TextUser1 on photo 1",UserId = 1},
                new Comments() {PhotoId = 2,CommentText = "TextUser1 on photo 2",UserId = 1},
                new Comments() {PhotoId = 2,CommentText = "TextUser3 on photo 2",UserId = 3},
                new Comments() {PhotoId = 3,CommentText = "TextUser2 on photo 3",UserId = 2}
            };
            db.Comments.AddRange(comments);
            db.SaveChanges();
        }
    }
}
