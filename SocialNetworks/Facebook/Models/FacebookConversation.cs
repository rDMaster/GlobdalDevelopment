using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookConversation
    {
        public string ID { get; set; }
        public string Snippet { get; set; }
        public string UpdatedTime { get; set; }
        public int MessageCount { get; set; }
        public int UnreadCount { get; set; }
        public object Tags { get; set; }
        public FacebookUser[] Participants { get; set; }
        public FacebookUser[] Senders { get; set; }
        public bool CanReply { get; set; }
        public bool IsSubscribed { get; set; }
        public FacebookConversation()
        {

        }
    }
}
