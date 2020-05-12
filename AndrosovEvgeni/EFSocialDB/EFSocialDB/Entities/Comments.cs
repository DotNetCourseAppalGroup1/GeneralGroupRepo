using System.Collections.Generic;

namespace EFSocialDB.Entities
{
    public class Comments : EntityModel
    {
        public Comments()
        {
            this.CommentLikes = new HashSet<CommentLikes>();
        }

        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
        public virtual ICollection<CommentLikes> CommentLikes { get; set; }
        public virtual Photos Photos { get; set; }
        public virtual Users Users { get; set; }
    }
}
