using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.SocialNetworks.Facebook.Models
{
    public class FacebookUserContext
    {
        /// <summary>
        /// The token representing the social context.
        /// </summary>
        public string ID { get; set; }
        public List<FacebookUser> MutualFriends { get; set; }
        public List<FacebookPage> MutualLikes { get; set; }
        public FacebookUserContext(JToken token)
        {
            JObject obj = JObject.Parse(token.ToString());
            ID = (obj["id"] ?? "NA").ToString();
        }
    }
}
