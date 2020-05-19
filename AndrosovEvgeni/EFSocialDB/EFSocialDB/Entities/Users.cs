using System.Collections.Generic;

namespace EFSocialDB.Entities
{
    public class Users : EntityModel
    {
        public Users()
        {
            this.CommentLikes = new HashSet<CommentLikes>();
            this.Comments = new HashSet<Comments>();
            this.PhotoLikes = new HashSet<PhotoLikes>();
            this.Photos = new HashSet<Photos>();
            this.ProfileLikes = new HashSet<ProfileLikes>();
        }

        public string Name { get; set; }
        public virtual ICollection<CommentLikes> CommentLikes { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<PhotoLikes> PhotoLikes { get; set; }
        public virtual ICollection<Photos> Photos { get; set; }
        public virtual ICollection<ProfileLikes> ProfileLikes { get; set; }
    }
}
