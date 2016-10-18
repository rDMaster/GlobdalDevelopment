using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookGroup
    {
        /// <summary>
        /// The group ID.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Information about the group's cover photo.
        /// </summary>
        public FacebookCover Cover { get; set; }
        /// <summary>
        /// Them email address to upload content to the group. Only current members of the group can use this.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The URL for the group's icon.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// The number of pending member requests.
        /// </summary>
        public int MemberRequestCount { get; set; }
        /// <summary>
        /// The name of the group.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The profile that created this group, , either this or the 'ownerUser' property shall be null depending on profile creation type.
        /// </summary>
        public FacebookPage OwnerPage { get; set; }
        /// <summary>
        /// The profile that created this group, either this or the 'ownerPage' property shall be null depending on profile creation type.
        /// </summary>
        public FacebookUser OwnerUser { get; set; }
        /// <summary>
        /// The privacy setting of the group. Possible values: Closed | Open | Secret.
        /// </summary>
        public string Privacy { get; set; }
        /// <summary>
        /// The last time the group was updated.
        /// </summary>
        public DateTime UpdatedTime { get; set; }
        public FacebookGroup(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
            Cover = new FacebookCover(obj["cover"]);
            Email = (obj["email"] ?? "NA").ToString();
            Icon = (obj["icon"] ?? "NA").ToString();
            MemberRequestCount = int.Parse((obj["member_request_count"] ?? "0").ToString());
            Name = (obj["name"] ?? "NA").ToString();
            Privacy = (obj["privacy"] ?? "NA").ToString();
            UpdatedTime = DateTime.Parse((obj["updated_time"] ?? DateTime.Now.ToString()).ToString());
        }
    }
}
