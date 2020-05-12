using System;
using System.Collections.Generic;
namespace EFSocialDB.Entities
{
    public class PhotoLikes : EntityModel
    {
        public int PhotoId { get; set; }
        public int UserId { get; set; }

        public virtual Photos Photos { get; set; }
        public virtual Users Users { get; set; }
    }
}
