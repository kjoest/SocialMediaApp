using Microsoft.AspNet.Identity;
using SocialMedia.Data.CommentData;
using SocialMedia.Data.MediaData;
using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.PostData
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Visibility Visibilitiy { get; set; }
        [Required]
        public TypeOfPost TypeOfPost { get; set; }
        [Required]
        public int CommentCount { get; set; }
        [Required]
        public int LikeCount { get; set; }
        [Required]
        public int ShareCount { get; set; }
        public string Hashtag { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Media> Medias { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }
        public virtual Media Media { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }

    public enum Visibility
    {
        Public,
        Private,
        Friends
    }

    public enum TypeOfPost
    {
        Text,
        Image,
        Video
    }
}
