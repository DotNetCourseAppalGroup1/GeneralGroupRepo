using System.Data.Entity;
using EFSocialDB.DatabaseConfigurations;
using EFSocialDB.Entities;

namespace DatabaseContext
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DbConnection")
        { }
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new SocialDbInitializer());
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CommentLikes> CommentLikes { get; set; }
        public DbSet<PhotoLikes> PhotoLikes { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<ProfileLikes> ProfileLikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new PhotosConfiguration());
        }
    }
}
