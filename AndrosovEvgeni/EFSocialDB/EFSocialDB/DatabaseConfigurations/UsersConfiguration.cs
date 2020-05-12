using System.Data.Entity.ModelConfiguration;
using EFSocialDB.Entities;

namespace EFSocialDB.DatabaseConfigurations
{
    class UsersConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersConfiguration()
        {
            ToTable("Profiles");
            Property(p => p.Name).HasMaxLength(30).HasColumnName("UserName");
        }
    }
}
