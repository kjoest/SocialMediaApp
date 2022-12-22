using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.PostModels
{
    public class PostEdit
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
    }
}
