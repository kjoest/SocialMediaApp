using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.DirectMessageData
{
    public class DirectMessage
    {
        [Key]
        public int DirectMessageId { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTimeOffset SentDate { get; set; }

        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public User Sender { get; set; }

        [ForeignKey(nameof(Receiver))]
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}
