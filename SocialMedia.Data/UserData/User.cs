using SocialMedia.Data.CommentData;
using SocialMedia.Data.DirectMessageData;
using SocialMedia.Data.FollowerData;
using SocialMedia.Data.FollowingData;
using SocialMedia.Data.LikeData;
using SocialMedia.Data.MediaData;
using SocialMedia.Data.PostData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.UserData
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public string Bio { get; set; }
        public string ProfilePicture { get; set; }
        public int FollowerCount { get; set; }
        public int FollowingCount { get; set; }
        public Status Status { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Following> Following { get; set; }
        public ICollection<Media> Medias { get; set; }
        public ICollection<DirectMessage> SentMessages { get; set; }
        public ICollection<DirectMessage> ReceivedMessages { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }
        public DateTimeOffset? LastActive { get; set; }
       
    }

    public enum Status
    {
        Active,
        Blocked,
        Deleted
    }
}
