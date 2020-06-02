using SocialNetwork3.Models.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual LikePhoto LikePhoto { get; set; }
        public Photo()
        {
            Comments = new List<Comment>();
        }
    }
}
