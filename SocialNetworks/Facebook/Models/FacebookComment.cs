using GlobalDevelopment.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookComment
    {
        public string ID { get; set; }
        public FacebookStoryAttachment Attachment { get; set; }
        public bool CanComment { get; set; }
        public bool CanRemove { get; set; }
        public bool CanHide { get; set; }
        public bool CanLike { get; set; }
        public bool CanReplyPrivately { get; set; }
        public int CommentCount { get; set; }
        public string CreatedTime { get; set; }
        public FacebookUser From { get; set; }
        public int LikeCount { get; set; }
        public string Message { get; set; }
        public FacebookUser[] MessageTags { get; set; }
        public FacebookComment Parent { get; set; }
        public bool UserLikes { get; set; }
        public FacebookComment(string id)
        {
        }
    }
}