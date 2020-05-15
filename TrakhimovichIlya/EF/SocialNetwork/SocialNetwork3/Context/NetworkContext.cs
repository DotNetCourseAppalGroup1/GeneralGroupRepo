using SocialNetwork3.Models;
using SocialNetwork3.Models.Likes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.Context
{
    public class NetworkContext : DbContext
    {
        public NetworkContext() : base("NetworkConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikePhoto> LikePhotos { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LikePhoto>().HasKey(lp => new { lp.UserId, lp.PhotoId });
            modelBuilder.Entity<LikeComment>().HasKey(lc => new { lc.UserId, lc.CommentId });

            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(20);
            modelBuilder.Entity<Photo>().Property(p => p.Description).HasMaxLength(50);
            modelBuilder.Entity<Comment>().Property(c => c.Text).HasMaxLength(300);

            modelBuilder.Entity<User>().HasMany(u => u.Photos).WithRequired(p => p.User);
            modelBuilder.Entity<User>().HasMany(u => u.Comments).WithRequired(c => c.User);
            modelBuilder.Entity<Photo>().HasMany(p => p.Comments).WithRequired(p => p.Photo);

            modelBuilder.Entity<LikePhoto>().HasRequired(lp => lp.User).WithRequiredPrincipal(u => u.LikePhoto);
            modelBuilder.Entity<LikePhoto>().HasRequired(lp => lp.Photo).WithRequiredPrincipal(p => p.LikePhoto);
            modelBuilder.Entity<LikeComment>().HasRequired(lc => lc.User).WithRequiredPrincipal(u => u.LikeComment);
            modelBuilder.Entity<LikeComment>().HasRequired(lc => lc.Comment).WithRequiredPrincipal(c => c.LikeComment);

            base.OnModelCreating(modelBuilder);
        }
    }
}
