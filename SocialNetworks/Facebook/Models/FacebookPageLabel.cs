using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookPageLabel
    {
        /// <summary>
        /// Time when the label was created.
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// Admin who created the label.
        /// </summary>
        public FacebookProfile Creator { get; set; }
        /// <summary>
        /// Page that owns the label.
        /// </summary>
        public FacebookPage From { get; set; }
        /// <summary>
        /// ID of the label.
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Name of the label.
        /// </summary>
        public string Name { get; set; }
        public FacebookPageLabel(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            CreationTime = DateTime.Parse((obj["creation_time"] ?? DateTime.Now.ToString()).ToString());
            Creator = new FacebookProfile(obj["creator_id"]);
            From = new FacebookPage(obj["from"]);
            ID = (obj["id"] ?? "NA").ToString();
            Name = (obj["name"] ?? "NA").ToString();
        }
    }
}
