using SocialNetwork3.Models.Likes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual LikeComment LikeComment { get; set; }
        public virtual LikePhoto LikePhoto { get; set; }
        public User()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
        }
    }
}
