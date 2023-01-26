using SocialMedia.Data.PostData;
using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.LikeData
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public bool IsDeleted { get; set; }

        public DateTimeOffset LikedDate { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
