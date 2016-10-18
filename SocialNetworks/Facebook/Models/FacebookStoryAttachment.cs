using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookStoryAttachment
    {
        public string Description { get; set; }
        public List<FacebookTextRange> Description_tags { get; set; }
        public string AttachmentMedia { get; set; }
        public string AttachmentID { get; set; }
        public string AttachmentUrl { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public FacebookStoryAttachment(string description, List<FacebookTextRange> descriptionTags, string attackmentMedia, string attackmentID, string attachmentUrl, string type, string title, string url)
        {
            Description = description;
            Description_tags = descriptionTags;
            AttachmentMedia = attackmentMedia;
            AttachmentID = attackmentID;
            AttachmentUrl = attachmentUrl;
            Title = title;
            Url = url;
            Type = type;
        }
        public FacebookStoryAttachment(JObject obj)
        {
            Description = (obj["description"] ?? "NA").ToString();
            Description_tags = (object)(obj["description_tags"] ?? "NA") as List<FacebookTextRange>;
            AttachmentMedia = (obj["media"] ?? "NA").ToString();
            AttachmentID = (obj["target"] ?? "NA").ToString();
            AttachmentUrl = (obj["target"] ?? "NA").ToString();
            Title = (obj["title"] ?? "NA").ToString();
            Type = (obj["type"] ?? "NA").ToString();
            Url = (obj["url"] ?? "NA").ToString();
        }
    }
}