using System.Collections.Generic;

namespace EFSocialDB.Entities
{
    public class Photos : EntityModel
    {
        public Photos()
        {
            this.Comments = new HashSet<Comments>();
            this.PhotoLikes = new HashSet<PhotoLikes>();
        }

        public string PhotoDescription { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<PhotoLikes> PhotoLikes { get; set; }
        public virtual Users Users { get; set; }
    }
}
