using SocialNetwork3.Models.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? PhotoId { get; set; }
        public virtual Photo Photo { get; set; }
        public virtual LikeComment LikeComment { get; set; }

    }
}
