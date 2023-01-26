using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.FollowerData
{
    public class Follower
    {
        [Key]
        public int FollowerId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset FollowedDate { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public User FollowerUser { get; set; }


    }
}
