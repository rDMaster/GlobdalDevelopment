using GlobalDevelopment.Helpers;
using GlobalDevelopment.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPost
    {
        #region Properties
        /// <summary>
        /// The post ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Basic information about the admin, app or business that created the post. Applies to pages only.
        /// </summary>
        public FacebookPostCreator AdminCreator { get; set; }
        /// <summary>
        /// Information about the app this post was published by.
        /// </summary>
        public FacebookApp Application { get; set; }
        /// <summary>
        /// The caption of a link in a post (appears beneath the name).
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// The time the post was initially published. For a post about a life event, this will be the date and time of the life event.
        /// </summary>
        public string CreatedTime { get; set; }
        /// <summary>
        /// A description of a link in the post (appears beneath the caption).
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Information about the profile that posted the message.
        /// </summary>
        public FacebookUser From { get; set; }
        /// <summary>
        /// If this post is marked as hidden (Applies to pages only. Although visitor's post on page can not be approved using this field).
        /// </summary>
        public string IsHidden { get; set; }
        /// <summary>
        /// A link to an icon representing the type of this post.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Indicates whether a scheduled post was published (applies to sheduled page post only, for users posts and instantly published posts this value is always 'true'.
        /// </summary>
        public string IsPublished { get; set; }
        /// <summary>
        /// The link attached to this post.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The status message in the post.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        ///  The name of the link.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The ID of any uploaded photo or video attached to the post.
        /// </summary>
        public string AttachmentID { get; set; }
        /// <summary>
        /// Description of the type of a status update.
        /// </summary>
        public string StatusType { get; set; }
        /// <summary>
        /// The ID of a parent post for this post, if it exists. For example, if this story is a 'Your page was mentioned in a post' story. the parent ID will be the original post where the mention happened.
        /// </summary>
        public string ParentID { get; set; }
        public string Picture { get; set; }
        public FacebookPlace Place { get; set; }
        public FacebookPrivacy Privacy { get; set; }
        public string Source { get; set; }
        public string Story { get; set; }
        public string UpdatedTime { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public List<FacebookStoryTags> StoryTags { get; set; }
        #endregion
        #region Constructors
        public FacebookPost(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            BuildPost(obj);
        }
        public FacebookPost()
        {
        }
        #endregion
        #region Methods
        private void BuildPost(JObject obj)
        {
            ID = (obj["id"] ?? "NA").ToString();
            CreatedTime = (obj["created_time"] ?? "NA").ToString();
            IsHidden = (obj["is_hidden"] ?? "NA").ToString();
            IsPublished = (obj["is_published"] ?? "NA").ToString();
            Message = (obj["message"] ?? "NA").ToString();
            UpdatedTime = (obj["updated_time"] ?? "NA").ToString();
            StatusType = (obj["status_type"] ?? "NA").ToString();
            Picture = (obj["picture"] ?? "NA").ToString();
            Privacy = new FacebookPrivacy(obj["privacy"]);
            StoryTags = SetStoryTags(obj["story_tags"]);
            AttachmentID = (obj["object_id"] ?? "NA").ToString();
            ParentID = (obj["parent_id"] ?? "NA").ToString();
            if(obj["properties"] != null) SetProperties(obj["properties"]);
        }
        private void SetProperties(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            Name = (obj["name"] ?? "NA").ToString();
            Text = (obj["text"] ?? "NA").ToString();
            Url = (obj["href"] ?? "NA").ToString();
        }
        private List<FacebookStoryTags> SetStoryTags(JToken obj)
        {
            if (obj != null)
            {
                StoryTags = new List<FacebookStoryTags>();
                foreach (JToken storyTag in obj)
                {
                    FacebookStoryTags facebookStoryTag = new FacebookStoryTags(storyTag);
                    StoryTags.Add(facebookStoryTag);
                }
            } else
            {
                StoryTags = null;
            }
            return StoryTags;
        }
        #endregion
    }
}