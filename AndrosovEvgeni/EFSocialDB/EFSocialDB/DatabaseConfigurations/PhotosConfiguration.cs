using System.Data.Entity.ModelConfiguration;
using EFSocialDB.Entities;

namespace EFSocialDB.DatabaseConfigurations
{
    class PhotosConfiguration : EntityTypeConfiguration<Photos>
    {
        public PhotosConfiguration()
        {
            Property(p => p.UserId).HasColumnName("AuthorId");
            Property(p => p.PhotoDescription).HasMaxLength(100);
        }
    }
}
