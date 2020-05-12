using System.Data.Entity.ModelConfiguration;
using EFSocialDB.Entities;

class CommentConfiguration : EntityTypeConfiguration<Comments>
{
    public CommentConfiguration()
    {
        Property(p => p.UserId).HasColumnName("CommentAuthorId");
        Property(p => p.CommentText).HasMaxLength(100);
    }
}