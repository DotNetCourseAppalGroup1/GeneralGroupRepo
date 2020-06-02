using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.Models.Likes
{
    public class LikeComment
    {
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
