using GlobalDevelopment.Helpers;
using GlobalDevelopment.OAuth.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookAlbum
    {
        /// <summary>
        /// The album ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Whether the viewer can upload photos to this album.
        /// </summary>
        public bool CanUpload { get; set; }
        /// <summary>
        /// The approximate number of photos in the album.
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// The album's cover.
        /// </summary>
        public FacebookCover Cover { get; set; }
        /// <summary>
        /// The time the album was initially created.
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// The description of the album.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The event associated with this album.
        /// </summary>
        public FacebookEvent Event { get; set; }
        /// <summary>
        /// the profile that created the album.
        /// </summary>
        public FacebookUserInfo From { get; set; }
        /// <summary>
        /// A link to this album on facebook.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// The textual location of the album.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// The title of the album.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The place associated with this album.
        /// </summary>
        public FacebookPage Place { get; set; }
        /// <summary>
        /// The privacy settings for this album.
        /// </summary>
        public string Privacy { get; set; }
        /// <summary>
        /// The type of the album.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// The last time the album was updated.
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        public List<FacebookPhoto> Photos { get; set; }
        public FacebookAlbum(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            CanUpload = bool.Parse((obj["can_upload"] ?? "false").ToString());
            Count = int.Parse((obj["count"] ?? "0").ToString());
            if(obj["cover_photo"] != null)
                Cover = new FacebookCover(obj["cover_photo"]);
            CreatedTime = DateTime.Parse((obj["created_time"] ?? DateTime.Now.ToString()).ToString());
            Description = (obj["description"] ?? "NA").ToString();
            if (obj["event"] != null)
                Event = new FacebookEvent(obj["event"]);
            if (obj["from"] != null)
                From = new FacebookUserInfo(obj["from"]);
            Link = (obj["link"] ?? "NA").ToString();
            Location = (obj["location"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
            if (obj["place"] != null)
                Place = new FacebookPage(obj["place"]);
            Privacy = (obj["privacy"] ?? "NA").ToString();
            Type = (obj["type"] ?? "NA").ToString();
            UpdatedTime = DateTime.Parse((obj["updated_time"] ?? DateTime.Now.ToString()).ToString());
            var app = (OAuthApp)HttpContext.Current.Session[FacebookApi.SessionApp] as FacebookApp;
            Photos = new List<FacebookPhoto>();
            foreach(var photo in GeneralHelper.GetData("data", FacebookHelper.GetEdgeJson(ID, "photos", FacebookApi.PhotoFields, app.AccessToken)))
            {
                FacebookPhoto phot = new FacebookPhoto(photo);
                Photos.Add(phot);
            }
        }
    }
}