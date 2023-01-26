using SocialMedia.Data.UserData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.NotificationData
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        [ForeignKey(nameof(Sender))]
        public int SenderId { get; set; }
        public virtual User Sender { get; set; }

        [ForeignKey(nameof(Receiver))]
        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }
    }
}
