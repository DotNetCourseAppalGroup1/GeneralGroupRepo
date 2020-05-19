using System;
using System.Collections.Generic;
namespace EFSocialDB.Entities
{
    public class CommentLikes : EntityModel
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }

        public virtual Comments Comments { get; set; }
        public virtual Users Users { get; set; }
    }
}
