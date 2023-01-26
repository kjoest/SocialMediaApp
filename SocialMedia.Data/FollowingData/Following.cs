using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.FollowingData
{
    public class Following
    {
        [Key]
        public int FollowingId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public User FollowingUser { get; set; }
    }
}
