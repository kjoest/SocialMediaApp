using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string PostText { get; set; }
        public string ImagePath { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
