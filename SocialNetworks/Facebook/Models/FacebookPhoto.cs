using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPhoto
    {
        /// <summary>
        /// The photo id.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// The album this photo is in.
        /// </summary>
        public FacebookAlbumInfo Album { get; set; }
        /// <summary>
        /// A user-specified time for when this object was created.
        /// </summary>
        public DateTime BackdatedTime { get; set; }
        /// <summary>
        /// How accurate the backdates time is.
        /// </summary>
        public string BackdatedTimeGranularity { get; set; }
        /// <summary>
        /// Indicates whether the viewer can backdate the photo.
        /// </summary>
        public bool CanBackdate { get; set; }
        /// <summary>
        /// Indicates whether the viewer can delete the photo.
        /// </summary>
        public bool CanDelete { get; set; }
        /// <summary>
        /// Indicates whether the viewer can tag the photo.
        /// </summary>
        public bool CanTag { get; set; }
        /// <summary>
        /// The time the photos was published.
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// If this object has a place, the event associated with this place.
        /// </summary>
        public FacebookEvent Event { get; set; }
        /// <summary>
        /// The profile that uploaded this photo.
        /// </summary>
        public FacebookProfile From { get; set; }
        /// <summary>
        /// The height of this photo in pixels.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// The icon that Facebook displays when photos are published to news feed.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// The different stored representations of the photo.
        /// </summary>
        public List<FacebookPlatformSource> Images { get; set; }
        /// <summary>
        /// Last used time of this object by current viewer.
        /// </summary>
        public DateTime LastUsedTime { get; set; }
        /// <summary>
        /// link to the photo on facebook.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The user-provided caption given to this photo.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// An array containing an array of objects mentioned in the name field which contain the id, name and type of each object as well as the offset and length.
        /// </summary>
        public List<FacebookEntityAtTextRange> NameTags { get; set; }
        /// <summary>
        /// ID of the page story this corresponds to. May not be on all photos. Applies to only published photos.
        /// </summary>
        public string PageStoryID { get; set; }
        /// <summary>
        /// Link to 100px wide representation of this photo.
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// Locaion associated with the photo, if any.
        /// </summary>
        public FacebookPlace Place { get; set; }
        /// <summary>
        /// The target this photo is published to.
        /// </summary>
        public FacebookProfile Target { get; set; }
        /// <summary>
        /// The last time the photo was updated.
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        /// <summary>
        /// The differant stored representation of this photo in webp format.
        /// </summary>
        public List<FacebookPlatformSource> WebpImages { get; set; }
        /// <summary>
        /// The width of this photo in pixels.
        /// </summary>
        public int Width { get; set; }
        public FacebookPhoto(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            if(obj["album"] != null)
                Album = new FacebookAlbumInfo(obj["album"]);
            BackdatedTime = DateTime.Parse((obj["backdated_time"] ?? DateTime.Now.ToString()).ToString());
            BackdatedTimeGranularity = (obj["backdated_time_granularity"] ?? "NA").ToString();
            CanBackdate = bool.Parse((obj["can_backdate"] ?? "false").ToString());
            CanDelete = bool.Parse((obj["can_delete"] ?? "false").ToString());
            CanTag = bool.Parse((obj["can_tag"] ?? "false").ToString());
            CreatedTime = DateTime.Parse((obj["created_time"] ?? DateTime.Now.ToString()).ToString());
            if(obj["event"] != null)
                Event = new FacebookEvent(obj["event"]);
            if (obj["from"] != null)
                From = new FacebookProfile(obj["from"]);
            Height = int.Parse((obj["height"] ?? "0").ToString());
            Icon = (obj["icon"] ?? "NA").ToString();
            Images = new List<FacebookPlatformSource>();
            if (obj["images"] != null)
            {
                foreach (var image in obj["images"])
                {
                    FacebookPlatformSource i = new FacebookPlatformSource(image);
                    Images.Add(i);
                }
            }
            LastUsedTime = DateTime.Parse((obj["last_used_time"] ?? DateTime.Now.ToString()).ToString());
            Link = (obj["link"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
            if (obj["name_tags"] != null)
            {
                NameTags = new List<FacebookEntityAtTextRange>();
                foreach (var ct in obj["name_tags"])
                {
                    FacebookEntityAtTextRange nameTag = new FacebookEntityAtTextRange(ct);
                    NameTags.Add(nameTag);
                }
            }
            PageStoryID = (obj["page_story_id"] ?? "NA").ToString();
            Picture = (obj["picture"] ?? "NA").ToString();
            if (obj["place"] != null)
                Place = new FacebookPlace(obj["place"]);
            if (obj["target"] != null)
                Target = new FacebookProfile(obj["target"]);
            UpdatedTime = DateTime.Parse((obj["updated_time"] ?? DateTime.Now.ToString()).ToString());
            if (obj["webp_images"] != null)
            {
                WebpImages = new List<FacebookPlatformSource>();
                foreach (var pi in obj["webp_images"])
                {
                    FacebookPlatformSource pImage = new FacebookPlatformSource(pi);
                    WebpImages.Add(pImage);
                }
            }
            Width = int.Parse((obj["width"] ?? "0").ToString());
        }
    }
}
